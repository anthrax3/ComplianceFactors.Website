<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-lvcd-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Course.p_lvcd_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 600px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <div class="div_header_popup_1">
        Session:
    </div>
    <div>
        <asp:GridView ID="gvSession" RowStyle-CssClass="record" GridLines="None" CssClass="gridview_normal_800"
            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_session_system_id_pk"
            runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSession_RowDataBound" EmptyDataRowStyle-CssClass="empty_row" EmptyDataText="No result found.">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="horizontal_line" colspan="4">
                                    <hr>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                    &nbsp;
                                </td>
                                <td class="gridview_row_width_350">
                                    <asp:Label ID="lblSession1" runat="server"></asp:Label>
                                </td>
                                <td colspan="1">
                                    &nbsp;
                                </td>
                                <td class="gridview_row_width_350">
                                    <asp:Label ID="lblSession2" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
