<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sagp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.Popup.p_sagp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 800px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 200px;
            overflow: hidden;
        }
    </style>
<script type="text/javascript">
    function HideMsg() {
        $("[id*=divSuccess]").fadeOut(500);
    }
</script>
    <div id="content">
        <asp:ValidationSummary ID="vs_p_sagp" ValidationGroup="sagp" class="validation_summary_error"
            runat="server" />
        <div id="divError" runat="server" class="msgarea_error" style="display: none;" />
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;" />
        <div class="div_header_800">
            Add Parameter:
        </div>
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        Element:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlElement" runat="server" CssClass="ddl_user_advanced_search">
                            <asp:ListItem>UserName</asp:ListItem>
                            <asp:ListItem>FirstName</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Operator
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOperator" runat="server">
                            <asp:ListItem>Matches</asp:ListItem>
                            <asp:ListItem>Not Matches</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Values:
                        <asp:RequiredFieldValidator ID="rfvValues" runat="server" ValidationGroup="sagp"
                            ControlToValidate="txtValues" ErrorMessage="Please enter values.">&nbsp;</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtValues" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnAddParameter" runat="server" ValidationGroup="sagp" Text="Save and Add New Parameter"
                            OnClick="btnAddParameter_Click" />
                    </td>
                    <td colspan="6">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            
                            OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();" 
                            onclick="btnCancel_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
