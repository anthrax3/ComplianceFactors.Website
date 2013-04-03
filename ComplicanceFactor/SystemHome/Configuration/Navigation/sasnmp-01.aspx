<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeBehind="sasnmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Navigation.sasnmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
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

            $(".EditUi").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");

                //Get the GridView Row reference
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
                    'href': '../UI Texts and Labels/p-seul-01.aspx?mode=edit' + '&appname=' + record_id,
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
            $(".content").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                $.fancybox({
                    'type': 'iframe',
                    'titlePosition': 'over',
                    'titleShow': true,
                    'showCloseButton': true,
                    'scrolling': 'yes',
                    'autoScale': false,
                    'autoDimensions': false,
                    'helpers': { overlay: { closeClick: false} },
                    'width': 783,
                    'height': 200,
                    'margin': 0,
                    'padding': 0,
                    'overlayColor': '#000',
                    'overlayOpacity': 0.7,
                    'hideOnOverlayClick': false,
                    'href': '../UI Texts and Labels/p-seut-01.aspx?mode=edit' + '&appname=' + record_id,
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
            $(".newpage").click(function () {
                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
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
                    'href': '../Navigation/sasanp-01.aspx?id=' + record_id,
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

            $(".deleteui").click(function () {

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                var element = $(this).attr("id").split(",");
                if (confirm("Are you sure?")) {
                    $.ajax({
                        type: "POST",

                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "sasnmp-01.aspx/DeleteUI",

                        //Pass the selected record id"{'args': '" + record_id + "','args1': '" + element[1]+ "'}",
                        data: "{'args': '" + element[0] + "','args1': '" + element[1] + "'}",
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
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSave" CssClass="cursor_hand" runat="server" Text="Save"
                            OnClick="btnHeaderSave_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="Cancel"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_website_navigation_text")%>:
        </div>
        <br />
        <div class="width_auto_default">
            <asp:DataList ID="dlWebNav" runat="server"  ShowFooter="true" CellPadding="0" CssClass="grid_1000"
                CellSpacing="0" DataKeyField="s_web_nav_system_id_pk" OnItemDataBound="dlWebNav_ItemDataBound">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="width_200 item">
                                <%# Eval("s_web_nav_label_name")%>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="width_230">
                                <input type="button" id='<%# Eval("s_ui_text_name") + "_content" %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_content_button_text %>" />'
                                    class="content cursor_hand" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <%=LocalResources.GetLabel("app_label_text")%>:
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtNativeLabel" Text='<%# Eval("s_ui_label_us_english")%>' CssClass="textbox_250"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <input type="button" id='<%# Eval("s_web_nav_id") %>' value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                                    class=" EditUi cursor_hand" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            <asp:Label ID="lblVisible" runat="server" Text="<%$ LabelResourceExpression: app_visible_text %>" ></asp:Label>
                              
                            </td>
                            <td>
                                <asp:CheckBox ID="chkVisible"  Checked='<%# Eval("s_web_nav_active_flag")%>' runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="gvWebSubMenus" CellPadding="0"  CellSpacing="0" GridLines="None"
                        CssClass="grid_1000" ShowHeader="false" runat="server" ShowFooter="true" OnRowDataBound="gvWebSubMenus_RowDataBound"
                        AutoGenerateColumns="False" DataKeyNames="s_web_nav_id,s_web_nav_system_id_pk">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" class="record" cellspacing="0">
                                        <tr>
                                            <td class="width_200">
                                                ===>
                                                <%# Eval("s_web_nav_label_name")%>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td class="width_230">
                                                <input type="button" id='<%# Eval("s_ui_text_name") + "_content" %>' value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_content_button_text %>" />'
                                                    class="content cursor_hand" />
                                                <asp:Literal ID="ltlRemove" runat="server"></asp:Literal>
                                               <%-- <asp:Button ID="btnRemoveUI" CssClass="deleteui cursor_hand" runat="server" Text="Remove UI Page" />--%>
                                            </td>
                                            <%-- <td>
                                            
                                            </td>--%>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <%=LocalResources.GetLabel("app_label_text")%>:
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNativeLabel" Text='<%# Eval("s_ui_label_us_english")%>' CssClass="textbox_250"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input type="button" id='<%# Eval("s_web_nav_id") %>' value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                                                    class=" EditUi cursor_hand" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <%=LocalResources.GetLabel("app_visible_text")%>:
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkVisible" Checked='<%# Eval("s_web_nav_active_flag")%>' runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <%--<input type="button" id='btnAddNewPage1' value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_add_ui_page_button_text %>" />'
                                                    class="newpage cursor_hand" />--%>
                                                <%--<asp:Button ID="btnAddNewPage" runat="server" Text="<%$ LabelResourceExpression: app_add_ui_page_button_text %>" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <br />
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_application_navigation_text")%>
        </div>
        <br />
        <div>
            <table class="width_auto_default">
                <tr>
                    <td class="width_300">
                        <%=LocalResources.GetLabel("app_nav_employee")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="width_270">
                        <asp:TextBox ID="txtEmployee" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_employee" value='<asp:Literal ID="Literal1" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_nav_employee" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_emp_pod_mtraining_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtMyEmployeeTraining" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_emp_pod_mtraining_title" value='<asp:Literal ID="Literal2" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_emp_pod_mtraining_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_emp_pod_mlhistory_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeMyLearningHistory" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_emp_pod_mlhistory_title" value='<asp:Literal ID="Literal3" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_emp_pod_mlhistory_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_emp_pod_mcompliance_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmpMyCompliance" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_emp_pod_mcompliance_title" value='<asp:Literal ID="Literal4" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_emp_pod_mcompliance_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_emp_pod_mcatalog_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmpMyCatalog" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_emp_pod_mcatalog_title" value='<asp:Literal ID="Literal5" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_emp_pod_mcatalog_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td colspan="11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_nav_manager")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManager" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_manager" value='<asp:Literal ID="Literal6" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_nav_manager" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_home_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerHome" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_home_title" value='<asp:Literal ID="Literal7" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--  <asp:Button ID="app_manager_pod_home_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_mtodo_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerMyToDo" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_mtodo_title" value='<asp:Literal ID="Literal8" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_manager_pod_mtodo_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_mteam_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerMyTeamManage" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_mteam_title" value='<asp:Literal ID="Literal9" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--  <asp:Button ID="app_manager_pod_mteam_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_mreports_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerMyReports" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_mreports_title" value='<asp:Literal ID="Literal10" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--<asp:Button ID="app_manager_pod_mreports_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_mprofile_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerMyProfile" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_mprofile_title" value='<asp:Literal ID="Literal11" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_manager_pod_mprofile_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_browse_catalog_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerBrowseCatalog" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_browse_catalog_title" value='<asp:Literal ID="Literal12" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_manager_pod_browse_catalog_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_search_catalog_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerSearchCatalog" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_search_catalog_title" value='<asp:Literal ID="Literal13" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_manager_pod_search_catalog_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_manager_pod_splash_page_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtManagerSplashPage" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_manager_pod_splash_page_title" value='<asp:Literal ID="Literal14" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_manager_pod_splash_page_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td colspan="11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_nav_compliance")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompliance" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_compliance" value='<asp:Literal ID="Literal15" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_nav_compliance" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_mtodo_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplianceMyToDo" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_mtodo_title" value='<asp:Literal ID="Literal16" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--  <asp:Button ID="app_compliance_pod_mtodo_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_mdashboard_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompliancerMyDashboard" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_mdashboard_title" value='<asp:Literal ID="Literal17" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_compliance_pod_mdashboard_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_site_view_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompliancerSiteView" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_site_view_title" value='<asp:Literal ID="Literal18" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_compliance_pod_site_view_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_mhazard_analysis_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplianceHarm" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_mhazard_analysis_title" value='<asp:Literal ID="Literal19" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--  <asp:Button ID="app_compliance_pod_mhazard_analysis_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_mincident_report_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplianceGiris" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_mincident_report_title" value='<asp:Literal ID="Literal20" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_compliance_pod_mincident_report_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_certs_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplianceCerts" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_certs_title" value='<asp:Literal ID="Literal21" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_compliance_pod_certs" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_mreports_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplianceReports" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_mreports_title" value='<asp:Literal ID="Literal22" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_compliance_pod_mreports_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_compliance_pod_mark_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplianceMark" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_compliance_pod_mark_title" value='<asp:Literal ID="Literal23" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_compliance_pod_mark" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td colspan="11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_nav_instructor")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstructor" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_instructor" value='<asp:Literal ID="Literal24" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--<asp:Button ID="app_nav_instructor" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_instructor_pod_mtodo_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstructorMyToDo" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_instructor_pod_mtodo_title" value='<asp:Literal ID="Literal25" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_instructor_pod_mtodo_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_my_dashboard_text")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstructorMyDashboard" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_instructor_pod_mdashboard_title" value='<asp:Literal ID="Literal26" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_instructor_pod_mdashboard_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_instructor_pod_mclassroster_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstructorClassRosters" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_instructor_pod_mclassroster_title" value='<asp:Literal ID="Literal27" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--<asp:Button ID="app_instructor_pod_mclassroster_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_instructor_pod_mreports_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstructorReports" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_instructor_pod_mreports_title" value='<asp:Literal ID="Literal28" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--<asp:Button ID="app_instructor_pod_mreports_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td colspan="11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_nav_training")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTraining" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_training" value='<asp:Literal ID="Literal29" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_nav_training" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_training_pod_mtodo_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTrainingMyToDo" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_training_pod_mtodo_title" value='<asp:Literal ID="Literal30" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_training_pod_mtodo_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_training_pod_mdashboard_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTrainingMyDashBoard" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_training_pod_mdashboard_title" value='<asp:Literal ID="Literal31" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_training_pod_mdashboard_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_training_pod_mtraining_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTrainingMyTrainig" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_training_pod_mtraining_title" value='<asp:Literal ID="Literal32" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_training_pod_mtraining_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_training_pod_mtrainingcatalog_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTrainingManageCatalog" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_training_pod_mtrainingcatalog_title" value='<asp:Literal ID="Literal33" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_training_pod_mtrainingcatalog_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_training_pod_mreports_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTrainingReport" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_training_pod_mreports_title" value='<asp:Literal ID="Literal34" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--<asp:Button ID="app_training_pod_mreports_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td colspan="11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_nav_admin")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdministrator" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_admin" value='<asp:Literal ID="Literal35" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_nav_admin" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_admin_pod_minstructor_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txt_app_admin_pod_minstructor_title" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_admin_pod_minstructor_title" value='<asp:Literal ID="Literal36" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_admin_pod_minstructor_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_admin_pod_mtodo_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txt_app_admin_pod_mtodo_title" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_admin_pod_mtodo_title" value='<asp:Literal ID="Literal37" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_admin_pod_mtodo_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_admin_pod_mdashboard_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txt_app_admin_pod_mdashboard_title" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_admin_pod_mdashboard_title" value='<asp:Literal ID="Literal38" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_admin_pod_mdashboard_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_admin_pod_mcatalog_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txt_app_admin_pod_mcatalog_title" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_admin_pod_mcatalog_title" value='<asp:Literal ID="Literal39" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--  <asp:Button ID="app_admin_pod_mcatalog_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_admin_pod_mreports_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdministratorReports" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_admin_pod_mreports_title" value='<asp:Literal ID="Literal40" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_admin_pod_mreports_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_admin_pod_mark_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdministratorMark" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_admin_pod_mark_title" value='<asp:Literal ID="Literal41" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_admin_pod_mark_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td colspan="11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_nav_system")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtSystem" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_nav_system" value='<asp:Literal ID="Literal42" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_nav_system" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_system_pod_muser_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtSystemManageUsers" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_system_pod_muser_title" value='<asp:Literal ID="Literal43" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_system_pod_muser_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_system_pod_mcatalog_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtSystemManageCatalog" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_system_pod_mcatalog_title" value='<asp:Literal ID="Literal44" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%-- <asp:Button ID="app_system_pod_mcatalog_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
                <tr>
                    <td>
                        ===>
                        <%=LocalResources.GetLabel("app_system_pod_mconfiguration_title")%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_label_text")%>:
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtSystemManageConfiguration" CssClass="textbox_250" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="app_system_pod_mconfiguration_title" value='<asp:Literal ID="Literal45" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />'
                            class="EditUi cursor_hand" />
                        <%--   <asp:Button ID="app_system_pod_mconfiguration_title" runat="server" Text="<%$ LabelResourceExpression: app_manage_locales_button_text %>" />--%>
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
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div>
        <table cellpadding="0" cellspacing="0" class="paging">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterSave" CssClass="cursor_hand" runat="server" Text="Save"
                        OnClick="btnFooterSave_Click" />
                </td>
                <td align="right">
                    <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="Cancel"
                        OnClick="btnFooterCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
