<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-mcuccs-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.ManageCurriculum.Popup.p_mcuccs_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="div_header_700">
        Curriculum Details
    </div>
    <br />
    <div class="div_controls font_1">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    Curriculum Title (ID):
                </td>
                <td class="align_left" style="width: 130px;">
                    <asp:Label ID="lblCurriculumTitle" runat="server" Text=""></asp:Label>
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
                <td align="right">
                    Revision:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblRevision" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td align="right">
                    Description:
                </td>
                <td class="align_left">
                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="div_header_700">
        Change Status
    </div>
    <br />
    <div class="div_padding_40">
        <table>
            <tr>
                <td class="align_right">
                    Due Date
                </td>
                <td class="align_left">
                    <asp:CalendarExtender ID="ceDueDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtDueDate">
                    </asp:CalendarExtender>
                    <asp:TextBox ID="txtDueDate" class="CompletionDate" runat="server"></asp:TextBox>
                </td>
                <td class="align_right">
                    Notes
                </td>
                <td class="align_left">
                    <asp:TextBox runat="server" ID="txtNotes" Columns="30" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Select New Status:
                </td>
                <td>
                    <asp:DropDownList ID="ddlChangeStatus" DataTextField="s_curr_status_name" DataValueField="s_curr_status_system_id_pk"
                        runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="div_header_700">
        &nbsp;
    </div>
    <br />
    <div class="div_padding_135">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnChangeStatus" runat="server" Text="Change Status" CssClass="cursor_hand"
                        OnClick="btnChangeStatus_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="cursor_hand" 
                        onclick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
