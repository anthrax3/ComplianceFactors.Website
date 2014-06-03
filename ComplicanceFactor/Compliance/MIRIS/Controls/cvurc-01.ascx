<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cvurc-01.ascx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.Controls.cvurc_01" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="div_header_long">
    Root Cause Analysis Information:
</div>
<div class="div_long_textbox  font_1">
    <br />
    Incident Investgation Summary:
    <br />
    <br />
    <asp:Label ID="lblIncidentInvestigationSummary" Rows="3" cols="100" runat="server"
        CssClass="textarea_long_width" TextMode="MultiLine"></asp:Label>
    <br />
    <br />
    Do you have sufficient information to proceed with this Root Cause Analysis?
    <br />
    <br />
    <asp:Label ID="lblRcaSufficientInformation" runat="server"></asp:Label>
    <%--<asp:RadioButtonList ID="rbtnRcaSufficientInformation" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList>--%>
    <br />
    <br />
    Primary Effect
    <br />
    <br />
    <table style="width: 80%;" id="tbQuestions">
        <tr>
            <td style="width: 40px;">
                Question 1:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion1" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Answer 1:
            </td>
            <td>
                <asp:Label ID="lblAnswer1" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 30px;">
                Question 2:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion2" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Answer 2:
            </td>
            <td>
                <asp:Label ID="lblAnswer2" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 30px;">
                Question 3:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion3" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Answer 3:
            </td>
            <td>
                <asp:Label ID="lblAnswer3" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 30px;">
                Question 4:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion4" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Answer 4:
            </td>
            <td>
                <asp:Label ID="lblAnswer4" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 30px;">
                Question 5:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion5" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                Answer 5:
            </td>
            <td>
                <asp:Label ID="lblAnswer5" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 30px;">
                Question 6:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion6" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                Answer 6:
            </td>
            <td>
                <asp:Label ID="lblAnswer6" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 30px;">
                Question 7:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion7" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                Answer 7:
            </td>
            <td>
                <asp:Label ID="lblAnswer7" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 30px;">
                Question 8:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion8" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                Answer 8:
            </td>
            <td>
                <asp:Label ID="lblAnswer8" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 30px;">
                Question 9:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion9" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                Answer 9:
            </td>
            <td>
                <asp:Label ID="lblAnswer9" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr style="display: none;">
            <td style="width: 30px;">
                Question 10:(WHY?)
            </td>
            <td style="width: 100%;">
                <asp:Label ID="lblQuestion10" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                Answer 10:
            </td>
            <td>
                <asp:Label ID="lblAnswer10" runat="server" Rows="3" Width="100%" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    Root Cause Catagories
    <br />
    <br />
    <table style="width: 100%;">
        <tr style="text-align: left;">
            <td>
                People
            </td>
            <td>
                Procedures
            </td>
            <td>
                Hardware/Equipment
            </td>
            <td>
                Environment
            </td>
            <td>
                External
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRcaCatagoryPeople" runat="server"></asp:Label>
                <%--<asp:DropDownList ID="ddlRcaCategoryPeople" runat="server">
                    <asp:ListItem Text="Lack of Skill or Knowledge"></asp:ListItem>
                    <asp:ListItem Text="Procedure known but not used"></asp:ListItem>
                    <asp:ListItem Text="Procedure misinterpreted"></asp:ListItem>
                    <asp:ListItem Text="Training was inadequate"></asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td>
                <asp:Label ID="lblRcaCategoryProcedure" runat="server"></asp:Label>
                <%--<asp:DropDownList ID="ddlRcaCategoryProcedure" runat="server">
                    <asp:ListItem Text="Procedure non-existant"></asp:ListItem>
                    <asp:ListItem Text="Procedure is incorrect"></asp:ListItem>
                    <asp:ListItem Text="Procedure is incomplete"></asp:ListItem>
                    <asp:ListItem Text="Procedure was unknown"></asp:ListItem>
                    <asp:ListItem Text="Other procedure issues"></asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td>
                <asp:Label ID="lblRcaCategoryHardware" runat="server"></asp:Label>
                <%-- <asp:DropDownList ID="ddlRcaCategoryHardware" runat="server">
                    <asp:ListItem Text="Defective design"></asp:ListItem>
                    <asp:ListItem Text="Defective installation"></asp:ListItem>
                    <asp:ListItem Text="Inadequate design"></asp:ListItem>
                    <asp:ListItem Text="Ergonomically incorrect"></asp:ListItem>
                    <asp:ListItem Text="Preventative maintenance"></asp:ListItem>
                    <asp:ListItem Text="neglected"></asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td>
                <asp:Label ID="lblRcaCategoryEnvironment" runat="server"></asp:Label>
                <%-- <asp:DropDownList ID="ddlRcaCategoryEnvironment" runat="server">
                    <asp:ListItem Text="High Wind"></asp:ListItem>
                    <asp:ListItem Text="Rain"></asp:ListItem>
                    <asp:ListItem Text="Fog"></asp:ListItem>
                    <asp:ListItem Text="Snow"></asp:ListItem>
                    <asp:ListItem Text="Illumination"></asp:ListItem>
                    <asp:ListItem Text="Illumination"></asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td>
                <asp:Label ID="lblRcaCategoryEternal" runat="server"></asp:Label>
                <%-- <asp:DropDownList ID="ddlRcaCategoryEternal" runat="server">
                    <asp:ListItem Text="Uncontrollable"></asp:ListItem>
                </asp:DropDownList>--%>
            </td>
        </tr>
    </table>
</div>
<br />
<div class="div_header_long">
    <%=LocalResources.GetLabel("app_corrective_action_information_text")%>:
</div>
<br />
<div class="div_long_textbox font_1">
    <br />
    Corrective Action Solutions:
    <br />
    <br />
    <asp:Label ID="lblRcaCorrectiveAction" runat="server"></asp:Label>
    <%--<asp:DropDownList ID="ddlRcaCorrectiveAction" runat="server">
        <asp:ListItem Text="Coaching"></asp:ListItem>
        <asp:ListItem Text="Training"></asp:ListItem>
        <asp:ListItem Text="DisiplineISIPLINE"></asp:ListItem>
        <asp:ListItem Text="Equipment Repair or Replacement"></asp:ListItem>
        <asp:ListItem Text="Procedural Development"></asp:ListItem>
        <asp:ListItem Text="Policy Development"></asp:ListItem>
    </asp:DropDownList>--%>
    <br />
    <br />
    Solution:
    <br />
    <br />
    <asp:Label ID="lblSolution" Rows="3" cols="100" runat="server" CssClass="textarea_long_width"
        TextMode="MultiLine"></asp:Label>
    <br />
    <br />
    Activators:
    <br />
    <br />
    <asp:Label ID="lblRcaActivators" runat="server"></asp:Label>
    <%-- <asp:DropDownList ID="ddlRcaActivators" runat="server">
        <asp:ListItem Text="Test Activators 1"></asp:ListItem>
        <asp:ListItem Text="Test Activators 2"></asp:ListItem>
        <asp:ListItem Text="Test Activators 3"></asp:ListItem>
        <asp:ListItem Text="Test Activators 4"></asp:ListItem>
        <asp:ListItem Text="Test Activators 5"></asp:ListItem>
        <asp:ListItem Text="Test Activators 6"></asp:ListItem>
    </asp:DropDownList>--%>
    <br />
    <br />
    Consequences:
    <br />
    <br />
    <asp:Label ID="lblRcaConsequences" runat="server"></asp:Label>
    <%--<asp:DropDownList ID="ddlRcaConsequences" runat="server">
        <asp:ListItem Text="Test Consequences 1"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 2"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 3"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 4"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 5"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 6"></asp:ListItem>
    </asp:DropDownList>--%>
    <br />
    <br />
    Follow Up - Timeline And By Whom:
    <br />
    <br />
    <table>
        <tr>
            <td>
                Assigned To:
            </td>
            <td>
                <asp:Label ID="lblAssignedTo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Assigned Completion Date:
            </td>
            <td>
                <%--<asp:CalendarExtender ID="ceExpireDate" Format="MM/dd/yyyy" TargetControlID="TextBox3"
                    runat="server">
                </asp:CalendarExtender>--%>
                <asp:Label ID="lblAssignedCompletionDate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    Preventative Actions: <span style="color: Green">Low--------------------</span><span
        style="color: Yellow">----------------------</span><span style="color: red">---------------------HIGH</span>
    <br />
    <br />
    <br />
    <br />
    Corrective Actions: <span style="color: Green">Low--------------------</span><span
        style="color: Yellow">----------------------</span><span style="color: red">---------------------HIGH</span>
    <br />
    <br />
    Verification of Completed Action:
    <br />
    <br />
    Is Verification required?
    <br />
    <br />
    <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList>--%>
    <asp:Label ID="lblIsVerification" runat="server"></asp:Label>
    <br />
    <br />
    <table>
        <tr>
            <td>
                Assigned To:
            </td>
            <td>
                <asp:Label ID="TextBox4" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Assigned Completion Date:
            </td>
            <td>
                <%-- <asp:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy" TargetControlID="TextBox3"
                    runat="server">
                </asp:CalendarExtender>--%>
                <asp:Label ID="TextBox5" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    VALIDATION OF EFFECTIVENESS
    <br />
    <br />
    How will Validation of Corrective Action Take Place?
    <br />
    <br />
    <asp:Label ID="TextBox6" Rows="3" cols="100" runat="server" CssClass="textarea_long_width"
        TextMode="MultiLine"></asp:Label>
    <br />
    <br />
    Will Validation be based upon the individual or a group?
    <br />
    <br />
    <asp:Label ID="lblValidation" runat="server"></asp:Label>
    <%--<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList>--%>
</div>
<script type="text/javascript">
    var count = 4;

    function addQuestion() {
        if (count < 10) {

            $("#tbQuestions tr").eq(count * 3).show();
            $("#tbQuestions tr").eq(count * 3 + 1).show();
            $("#tbQuestions tr").eq(count * 3 + 2).show();
            count++;
        }

    }

    $(document).ready(function () {

        var i = 8;
        $("#tbQuestions tr").each(function () {
            if (i > 3) {
                if ($("#tbQuestions tr").eq(i * 3).find("textarea").val() == "") {

                    $("#tbQuestions tr").eq(i * 3).hide();
                    $("#tbQuestions tr").eq(i * 3 + 1).hide();
                    $("#tbQuestions tr").eq(i * 3 + 2).hide();
                } else {
                    $("#tbQuestions tr").eq(i * 3).show();
                    $("#tbQuestions tr").eq(i * 3 + 1).show();
                    $("#tbQuestions tr").eq(i * 3 + 2).show();
                }
            }
            i--;
        });




    });
</script>
