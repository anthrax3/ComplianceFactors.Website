<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="urc-01.ascx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.Controls.urc_01" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="div_header_long">
    <%=LocalResources.GetLabel("app_root_cause_analysis_infornation_text")%>:
</div>
<div class="div_long_textbox  font_1">
    <br />
    Incident Investgation Summary:
    <br />
    <br />
    <asp:TextBox ID="txtIncidentInvestigationSummary" Rows="3" cols="100" runat="server"
        CssClass="textarea_long_width" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    Do you have sufficient information to proceed with this Root Cause Analysis?
    <br />
    <br />
    <asp:RadioButtonList ID="rbtnRcaSufficientInformation" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    Primary Effect
    <br />
    <br />
    <table style="width: 80%;">
        <tr>
            <td style="width: 40px;">
               Question 1:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion1" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 1:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer1" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 2:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion2" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 2:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer2" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 3:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion3" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 3:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer3" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 4:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion4" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 4:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer4" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 5:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion5" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 5:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer5" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 6:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion6" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 6:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer6" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 7:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion7" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 7:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer7" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 8:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion8" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 8:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer8" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 9:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion9" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 9:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer9" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr><td colspan="2"><hr/></td></tr>
        <tr>
            <td style="width: 30px;">
               Question 10:
            </td>
           <td style="width: 100%;">
                 <asp:TextBox ID="txtQuestion10" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
           </td>
        </tr>
        <tr>
            <td>
               Answer 10:
            </td>
           <td>
                 <asp:TextBox ID="txtAnswer10" runat="server" Rows="3"  Width="100%" TextMode="MultiLine"></asp:TextBox>  
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
                <asp:DropDownList ID="ddlRcaCategoryPeople" runat="server">
                    <asp:ListItem Text="Lack of Skill or Knowledge"></asp:ListItem>
                    <asp:ListItem Text="Procedure known but not used"></asp:ListItem>
                    <asp:ListItem Text="Procedure misinterpreted"></asp:ListItem>
                    <asp:ListItem Text="Training was inadequate"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlRcaCategoryProcedure" runat="server">
                    <asp:ListItem Text="Procedure non-existant"></asp:ListItem>
                    <asp:ListItem Text="Procedure is incorrect"></asp:ListItem>
                    <asp:ListItem Text="Procedure is incomplete"></asp:ListItem>
                    <asp:ListItem Text="Procedure was unknown"></asp:ListItem>
                    <asp:ListItem Text="Other procedure issues"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlRcaCategoryHardware" runat="server">
                    <asp:ListItem Text="Defective design"></asp:ListItem>
                    <asp:ListItem Text="Defective installation"></asp:ListItem>
                    <asp:ListItem Text="Inadequate design"></asp:ListItem>
                    <asp:ListItem Text="Ergonomically incorrect"></asp:ListItem>
                    <asp:ListItem Text="Preventative maintenance"></asp:ListItem>
                    <asp:ListItem Text="neglected"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlRcaCategoryEnvironment" runat="server">
                    <asp:ListItem Text="High Wind"></asp:ListItem>
                    <asp:ListItem Text="Rain"></asp:ListItem>
                    <asp:ListItem Text="Fog"></asp:ListItem>
                    <asp:ListItem Text="Snow"></asp:ListItem>
                    <asp:ListItem Text="Illumination"></asp:ListItem>
                    <asp:ListItem Text="Illumination"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlRcaCategoryEternal" runat="server">
                    <asp:ListItem Text="Uncontrollable"></asp:ListItem>
                </asp:DropDownList>
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
    <asp:DropDownList ID="ddlRcaCorrectiveAction" runat="server">
        <asp:ListItem Text="Coaching"></asp:ListItem>
        <asp:ListItem Text="Training"></asp:ListItem>
        <asp:ListItem Text="DisiplineISIPLINE"></asp:ListItem>
        <asp:ListItem Text="Equipment Repair or Replacement"></asp:ListItem>
        <asp:ListItem Text="Procedural Development"></asp:ListItem>
        <asp:ListItem Text="Policy Development"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    Solution:
    <br />
    <br />
    <asp:TextBox ID="TextBox1" Rows="3" cols="100" runat="server" CssClass="textarea_long_width"
        TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    Activators:
    <br />
    <br />
    <asp:DropDownList ID="ddlRcaActivators" runat="server">
        <asp:ListItem Text="Test Activators 1"></asp:ListItem>
        <asp:ListItem Text="Test Activators 2"></asp:ListItem>
        <asp:ListItem Text="Test Activators 3"></asp:ListItem>
        <asp:ListItem Text="Test Activators 4"></asp:ListItem>
        <asp:ListItem Text="Test Activators 5"></asp:ListItem>
        <asp:ListItem Text="Test Activators 6"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    Consequences:
    <br />
    <br />
    <asp:DropDownList ID="ddlRcaConsequences" runat="server">
        <asp:ListItem Text="Test Consequences 1"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 2"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 3"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 4"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 5"></asp:ListItem>
        <asp:ListItem Text="Test Consequences 6"></asp:ListItem>
    </asp:DropDownList>
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
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Assigned Completion Date:
            </td>
            <td>
                <asp:CalendarExtender ID="ceExpireDate" Format="MM/dd/yyyy" TargetControlID="TextBox3"
                    runat="server">
                </asp:CalendarExtender>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <table>
        <tr>
            <td>
                Assigned To:
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Assigned Completion Date:
            </td>
            <td>
                <asp:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy" TargetControlID="TextBox3"
                    runat="server">
                </asp:CalendarExtender>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
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
    <asp:TextBox ID="TextBox6" Rows="3" cols="100" runat="server" CssClass="textarea_long_width"
        TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    Will Validation be based upon the individual or a group?
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList>
</div>
