<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-samcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.AddCompletion.p_samcp_01" %>

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
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 430px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addCatalog").fancybox({
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
                'href': '../../Catalog/MassCompletions/p-mcsc-01.aspx',
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".deleteCourse").click(function () {
                var hdnValue = document.getElementById('<%= hdnIsCatalogBind.ClientID %>');
                hdnValue.value = 0;

                //Get the Id of the record to delete
                var record_id = $(this).attr("id");
                //Get the GridView Row reference
                var tr_id = $(this).parents("#.record");
                // Ask user's confirmation before delete records
                if (confirm("Are you sure?")) {

                    $.ajax({
                        type: "POST",
                        //sasw-01.aspx is the page name and delete locale is the server side method to delete records in sacatvml-01.aspx.cs
                        url: "p-samcp-01.aspx/DeleteCourse",
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
    <script type="text/javascript" language="javascript">
        function validateCheckBoxes(sender, args) {
            var gvRows = $("#<%=gvCatalog.ClientID %> tr").length;
            if (gvRows == 0) {
                args.IsValid = false;
            }
            else {
                var gridView = document.getElementById('<%= gvCatalog.ClientID %>');
                for (var i = 0; i < gridView.rows.length; i++) {
                    var dropdowns = gridView.getElementsByTagName('select');
                    if (dropdowns.item(i).value == 'Select a Delivery') {
                        args.IsValid = false;
                        break; //break the loop as there is no need to check further.
                    }
                }
            }
        }        
    </script>
    <script type="text/javascript">
        function validateCompletion(sender, args) {
            var gridCompletion = document.getElementById('<%= gvCompletionInfo.ClientID %>');
            if (gridCompletion.rows.length > 1) {
                for (var i = 1; i < gridCompletion.rows.length; i++) {
                    var inputs = gridCompletion.rows[i].getElementsByTagName('input');
                    if (inputs[0].type == "text") {
                        if (inputs[0].value == '') {
                            args.IsValid = false;
                            break;
                        }
                    }
                }
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <script type="text/javascript">
        function CheckScore(sender, args) {
            var gridCompletion = document.getElementById('<%=gvCompletionInfo.ClientID %>');
            for (var i = 1; i < gridCompletion.rows.length; i++) {
                var inputs = gridCompletion.rows[i].getElementsByTagName('input');
                if (inputs[1].type == "text") {
                    if (inputs[1].value > 100) {
                        args.IsValid = false;
                        break;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function validateCourse(sender, args) {
            var gvRows = $("#<%=gvCatalog.ClientID %> tr").length;
            if (gvRows == 0) {
                args.IsValid = false;
            }
        }        
    </script>
    <script type="text/javascript">
        function validateAll() {
            var isValid = false;
            isValid = Page_ClientValidate('coursevalidation');

            if (isValid) {
                isValid = Page_ClientValidate('selectdelivery');
            }

            if (isValid) {
                isValid = Page_ClientValidate('samcp_completion');
            }
            if (isValid) {
                isValid = Page_ClientValidate('samcp_score');
            }
            return isValid;
        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdEditUser" runat="server" />
    <asp:HiddenField ID="hdnIsCatalogBind" runat="server" />
    <div id="content">
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samep_course_emp"
            runat="server" ValidationGroup="coursevalidation"></asp:ValidationSummary>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp" runat="server"
            ValidationGroup="selectdelivery"></asp:ValidationSummary>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp_score" runat="server"
            ValidationGroup="samcp_score"></asp:ValidationSummary>
        <asp:ValidationSummary class="validation_summary_error" ID="ValidationSummary1" runat="server"
            ValidationGroup="samcp_completion"></asp:ValidationSummary>

        <asp:CustomValidator ID="cvValidateCourse" EnableClientScript="true" ClientValidationFunction="validateCourse"
            ValidateEmptyText="true" ValidationGroup="coursevalidation" runat="server" ErrorMessage="Please select atleast one courses">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateCheckboxes" EnableClientScript="true" ClientValidationFunction="validateCheckBoxes"
            ValidationGroup="selectdelivery" runat="server" ErrorMessage="Please select the delivery">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateCompletion" EnableClientScript="true" ClientValidationFunction="validateCompletion"
            ValidationGroup="samcp_completion" runat="server" ErrorMessage="Please select date">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateScore" EnableClientScript="true" ClientValidationFunction="CheckScore"
            ValidationGroup="samcp_score" runat="server" ErrorMessage="Score does not exceed 100">&nbsp;</asp:CustomValidator>
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div id="divError" runat="server" class="msgarea_error" style="display: none;">
        </div>
        <div class="div_header">
            My Courses:
        </div>
        <br />
        <div class="clear">
        </div>
        <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" RowStyle-CssClass="record"
            CssClass=" grid_870" ShowHeader="false" ShowFooter="false" GridLines="None" DataKeyNames="c_course_system_id_pk"
            runat="server" OnRowDataBound="gvCatalog_RowDataBound" OnRowCommand="gvCatalog_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblCourse" runat="server" Style="text-align: left;" Text="Course:"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="gridview_row_width_4_1" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseName" runat="server" Style="text-align: left;" Text='<%#Eval("c_course_title")  + "(" + Eval("c_course_id_pk") +")"%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" CssClass="gridview_row_width_4_1"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlDelivery" CssClass="ddl_user_advanced_search" DataTextField="deliveryname"
                            DataValueField="c_delivery_system_id_pk" onchange="Page_BlockSubmit = false;"
                            runat="server" OnSelectedIndexChanged="ddlDelivery_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnRemoveCatalogItem" OnClientClick="return confirmStatus();" CommandName="Remove"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"
                            Text="Remove" />
                        <%--<input type="button" id='<%# Eval("c_course_system_id_pk") %>' value='<asp:Literal ID="Literal1" runat="server" Text="Remove" />'
                            class="deleteCourse cursor_hand" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="record"></RowStyle>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnAddCatalogItem" runat="server" CssClass="addCatalog cursor_hand"
            Text="Add Catalog" />
        <br />
        <br />
        <div class="div_header">
            Completion Information
        </div>
        <br />
        <br />
        <div class="clear">
        </div>
        <div class="div_controls font_1">
            <asp:GridView ID="gvCompletionInfo" CellPadding="0" CellSpacing="0" runat="server"
                EmptyDataText="No Result Found" GridLines="Both" DataKeyNames="c_delivery_id_pk"
                AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
                OnRowDataBound="gvCompletionInfo_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_4 align_center" HeaderStyle-BackColor="LightGray"
                        HeaderText="Delivery Name (ID)" ItemStyle-CssClass="gridview_row_width_4" ItemStyle-BorderStyle="Solid"
                        ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDeliveryIdName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_3 align_center" HeaderStyle-BackColor="LightGray"
                        HeaderText="Comments" ItemStyle-CssClass="gridview_row_width_3"
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtComments" Columns="20" TextMode="MultiLine">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1 align_center" HeaderStyle-BackColor="LightGray"
                        HeaderText="Completion Date" ItemStyle-CssClass="gridview_row_width_1" ItemStyle-BorderStyle="Solid"
                        ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtCompletionDate">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtCompletionDate" class="CompletionDate" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="LightGray" HeaderText="Attendance" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray" ItemStyle-BorderWidth="1px"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlAttendanceStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="LightGray" HeaderText="Passing Status"
                        HeaderStyle-CssClass="gridview_row_width_1 align_center" ItemStyle-CssClass="gridview_row_width_1"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray"
                        ItemStyle-BorderWidth="1px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPassignStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray"
                        ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlGrade" DataValueField="s_grading_scheme_system_value_id_pk"
                                DataTextField="s_grading_scheme_value_grade" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Score" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1 align_center"
                        ItemStyle-CssClass="gridview_row_width_1" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="LightGray"
                        ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtScore" CssClass="textbox_50" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div class="div_header">
            &nbsp;
        </div>
        <div class="font_1">
            <table class="table_td_300">
                <tr>
                    <%-- ValidationGroup="samcp_completion"--%>
                    <td class="align_right">
                        <asp:Button ID="btnProcessMassCompletion" runat="server" OnClientClick="return validateAll()"
                            Text="Process Completion" OnClick="btnProcessMassCompletion_Click" />
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
