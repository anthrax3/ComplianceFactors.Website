<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="mesc-01.aspx.cs" Inherits="ComplicanceFactor.Manager.Enroll.mesc_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
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
        function resetall() {
            document.getElementById('<%=txtEmployeeName.ClientID %>').value = '';
            document.getElementById('<%=txtEmployeeNumber.ClientID %>').value = '';

            return false;
        }
        function toggleSelection() {

            $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']").each(function (index) {
                $(this).attr('checked', false);
            });


        }

        function GetEmployeeCount() {
           
           
        }
        function validateCheckBoxes() {


         

            var isValid = false;
            var gridView = document.getElementById('<%= gvsearchDetails.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;

                            var counter = 0;
                            $("#<%=gvsearchDetails.ClientID%> input[id*='chkSelect']:checkbox").each(function (index) {
                                if ($(this).is(':checked'))
                                    counter++;
                            });

                            var maxenroll = $('#<%=hdnMe.ClientID%>').val();
                            var enrolledcount = $('#<%=hdEd.ClientID%>').val();
                            var result = parseInt(enrolledcount) + parseInt(counter);
                            var remaining = parseInt(maxenroll) - parseInt(enrolledcount);
                            if (result > maxenroll && maxenroll >0) {
                                alert("Sorry,  only "+remaining+" seats are available")
                                return false;
                            }
                            else {
                                return true;
                            }
                        }
                    }
                }
            }
            alert("Please select atleast one employee");
            return false;
        }

       
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:ValidationSummary CssClass="validation_summary_error" ID="vsMesc" runat="server"
        ValidationGroup="mesc"></asp:ValidationSummary>
    <asp:HiddenField ID="hdnMe" runat="server" />
    <asp:HiddenField ID="hdEd" runat="server" />
    <div class="div_header_800">
        Courses Details:
    </div>
    <div class="table_150">
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblCourseTitle" runat="server"></asp:Label>
                </td>
                <td>
                    Revision:
                    <asp:Label ID="lblRevision" runat="server"></asp:Label>
                </td>
                <td>
                    OLT - VLT - ILT
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    Description:<br />
                    <asp:Label ID="lblDescription" CssClass="font_normal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Approval:
                    <asp:Label ID="lblApproval" runat="server"></asp:Label>
                </td>
                <td>
                    Manager:
                    <asp:Label ID="lblManager" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Cost:
                    <asp:Label ID="lblCost" runat="server"></asp:Label>
                </td>
                <td>
                    CEU:
                    <asp:Label ID="lblCEU" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Owner:
                    <asp:Label ID="lblOwner" runat="server"></asp:Label>
                </td>
                <td>
                    Coordinator:
                    <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_800 tablesorter"
            runat="server" EmptyDataText="None" DataKeyNames="u_user_id_fk" AutoGenerateColumns="False"
            AllowPaging="true" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false"
            PageSize="5">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Employee Last Name" DataField='u_first_name' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Employee First Name" DataField='u_first_name' HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                    HeaderText="Employee Number" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="right">
        <input type="button" value="Remove Selected" onclick="toggleSelection();" class="cursor_hand" />
        <%--   <asp:Button ID="btnRemoveSelected" OnClientClick="toggleSelection();" CssClass="cursor_hand"
            runat="server" Text="Remove Selected" />--%>
    </div>
    <br />
    <br />
    <div class="clear">
    </div>
    <center>
        <div class="font_12_pixel">
            <br />
            <table>
                <tr>
                    <td>
                        Required: &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkRequired" runat="server" />&nbsp;&nbsp;&nbsp; Target Due Date:&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtTargetDueDate" Style="font-size: small;" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceTargetDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtTargetDueDate">
                        </asp:CalendarExtender>
                        <asp:RegularExpressionValidator ID="regexEndDate" runat="server" ControlToValidate="txtTargetDueDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                            ErrorMessage="Invalid target due date." Display="Dynamic" ValidationGroup="mesc">&nbsp;</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAssignOnly" OnClientClick="return validateCheckBoxes();" runat="server"
                            Text="Assign Only" OnClick="btnAssignOnly_Click" />
                        <asp:Button ID="btnRequestAssign" OnClientClick="return validateCheckBoxes();" runat="server"
                            Text="Request Assignment" Style="display: none;" OnClick="btnRequestAssignment_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnConfirmEnrollment" OnClientClick="return validateCheckBoxes();"
                            runat="server" Text="Confirm Enrollment(s)" OnClick="btnConfirmEnrollment_Click" />
                        <asp:Button ID="btnRequestEnrollment" OnClientClick="return validateCheckBoxes();"
                            runat="server" Text="Request Enrollment(s)" OnClick="btnRequestEnrollment_Click"
                            Style="display: none;" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </center>
    <br />
    <div>
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_800">
                Employee Search:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            employee Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            employee Number:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeNumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search" runat="server"
                                OnClick="btnGosearch_Click" />
                        </td>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" OnClientClick="return resetall();"
                                runat="server" />
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
