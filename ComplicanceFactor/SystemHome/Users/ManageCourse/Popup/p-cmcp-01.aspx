<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-cmcp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.ManageCourse.Popup.p_cmcp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
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
        function CheckScore(sender, args) {
            var score = document.getElementById('<%=txtScore.ClientID %>');
            if (score.value > 100) {
                args.IsValid = false;
            }
        }
    </script>
    <script type="text/javascript">
        function validateAll() {
            var isValid = false;
            isValid = Page_ClientValidate('selectdelivery');

            if (isValid) {
                isValid = Page_ClientValidate('samcp_score');
            }
            return isValid;
        }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div class="content_area_long">
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp" runat="server"
            ValidationGroup="selectdelivery"></asp:ValidationSummary>
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp_score" runat="server"
            ValidationGroup="samcp_score"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvValidateScore" EnableClientScript="true" ClientValidationFunction="CheckScore"
            ValidationGroup="samcp_score" runat="server" ErrorMessage="Score does not exceed 100">&nbsp;</asp:CustomValidator>
        <asp:CustomValidator ID="cvValidateCheckboxes" EnableClientScript="true" ClientValidationFunction="validateCheckBoxes"
            ValidationGroup="selectdelivery" runat="server" ErrorMessage="Please select the delivery">&nbsp;</asp:CustomValidator>
        <div class="div_header_700">
            Course Details
        </div>
        <br />
        <div>
            <asp:GridView ID="gvCatalog" AutoGenerateColumns="false" CssClass="grid_700" ShowHeader="false"
                ShowFooter="false" GridLines="None" runat="server" DataKeyNames="sysId" OnRowDataBound="gvCatalog_RowDataBound">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="gridview_row_width_4_1" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseCurriculumName" Style="text-align: left;" runat="server"
                                Text='<%#Eval("Id")  + "(" + Eval("title") +")"%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Literal ID="ltlViewDetails" runat="server" />
                            <asp:DropDownList ID="ddlDelivery" CssClass="ddl_user_advanced_search" Style="display: none;"
                                DataTextField="deliveryname" DataValueField="c_delivery_system_id_pk" AutoPostBack="true"
                                onchange="Page_BlockSubmit = false;" OnSelectedIndexChanged="ddlDelivery_SelectedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="clear">
        </div>
        <div class="div_header_700">
            Mark Completion details
        </div>
        <br />
        <div class="div_controls">
            <table>
                <tr>
                    <td class="align_right">
                        Attendance Status:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlAttendanceStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right">
                        Passing Status:
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlPassignStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_right">
                        Grade
                    </td>
                    <td class="align_left">
                        <asp:DropDownList ID="ddlGrade" DataValueField="s_grading_scheme_system_value_id_pk"
                            DataTextField="s_grading_scheme_value_grade" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_right">
                        Due Date
                    </td>
                    <td class="align_left">
                        <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtCompletionDate">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtCompletionDate" class="CompletionDate" runat="server"></asp:TextBox>
                    </td>
                    <td class="align_right">
                        Score
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtScore" CssClass="textbox_50" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Comments
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtComments" Columns="30" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnMarkCompletion" runat="server" OnClientClick="return validateAll()"
                            Text="Mark Completion" CssClass="cursor_hand" OnClick="btnMarkCompletion_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cursor_hand" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
