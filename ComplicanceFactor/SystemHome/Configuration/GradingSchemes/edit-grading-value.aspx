<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="edit-grading-value.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.GradingSchemes.edit_grading_value" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area_long">
        <div class="div_header_1005">
            Add Grading Value:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellspacing="10px">
                <tr>
                    <td class="text_align">
                        Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" CssClass="textarea_long_3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        Description:
                    </td>
                    <td>
                        <textarea id="txtDescription" rows="7" class="style1"></textarea>
                    </td>
                </tr>
            </table>
            <table cellspacing="10px">
                <tr>
                    <td class="text_align">
                        Minimum Percent Score:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMinScore_InPercentage" runat="server" CssClass="textbox_50"></asp:TextBox>%
                    </td>
                    <td class="text_align">
                        Maximum Score:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMaxScore_InPercentage" runat="server" CssClass="textbox_50"></asp:TextBox>%
                    </td>
                    <td class="text_align">
                        Grade Letter(s):
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtGrade" runat="server" CssClass="textbox_75"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        Minimum Numeric Grade:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMinScore_InNumbers" runat="server" CssClass="textbox_50"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        Maximum Numeric Grade:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtMaxScore_InNumbers" runat="server" CssClass="textbox_50"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        GPA:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtGpa" runat="server" CssClass="textbox_75"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text_align">
                        Descriptor:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescriptor" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        Qualification:
                    </td>
                    <td class="text_align">
                        <asp:TextBox ID="txtQualification" runat="server" CssClass="textbox_long"></asp:TextBox>
                    </td>
                    <td class="text_align">
                        Passing Status:
                    </td>
                    <td class="text_align">
                        <asp:DropDownList ID="ddlPassingStatus" runat="server" CssClass="width_30">
                            <asp:ListItem>Pass</asp:ListItem>
                            <asp:ListItem>Fail</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="text_align">
                        <asp:Button ID="btnSaveAndAdd" runat="server" Text="Save and Add New Value" />
                    </td>
                    <td colspan="3">
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
