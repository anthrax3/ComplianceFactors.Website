<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="p-lvcurd-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Curricula.p_lvcurd_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <script type="text/javascript">
        function RemoveLastTableCell() {

            $('#<%=gvEquivalencies.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvFulfillments.ClientID %> tr:last').eq(-1).css("display", "none");
            $('#<%=gvPrerequisites.ClientID %> tr:last').eq(-1).css("display", "none");
        }
       
    </script>
    <div class="div_header_700">
        Curriculum Details:
    </div>
    <div class="table_150">
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblCurriculumTitle" runat="server"></asp:Label>
                </td>
                <td>
                    Revision:
                    <asp:Label ID="lblRevision" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDeliveryType" runat="server"></asp:Label>
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
            <asp:DataList ID="dlPath" runat="server" ShowHeader="false" ShowFooter="true" CellPadding="0"
            CssClass="grid_870" CellSpacing="0" OnItemDataBound="dlPath_ItemDataBound" DataKeyField="c_curricula_path_system_id_pk">
            <ItemTemplate>
                <div class="div_header_700">
                    <%#Eval("c_curricula_path_name")%>
                </div>
                <br />
                <div class="div_controls font_1">
                    <asp:Label ID="lblCompleteSection" runat="server"></asp:Label>
                </div>
                <asp:GridView ID="gvSection" ShowHeader="false" CellPadding="0" CellSpacing="0" 
                    runat="server"  GridLines="None" OnRowDataBound="gvSection_RowDataBound" DataKeyNames="c_curricula_path_id_fk,c_curricula_path_section_id_pk"
                    AutoGenerateColumns="False" PagerSettings-Visible="false">
                    <RowStyle CssClass="record"></RowStyle>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <hr />
                                section:
                                <%#Eval("c_curricula_path_section_seq_number")%>
                                <asp:Label ID="lblComplete" runat="server"></asp:Label>
                                <asp:GridView ID="gvCourses" CellPadding="0" CellSpacing="0" CssClass="gridview_small_no_border"
                                    runat="server" EmptyDataText="No result found." GridLines="None" DataKeyNames="c_curricula_path_course_id_fk"
                                    AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" OnRowDataBound="gvCourses_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                            HeaderText="Course Title (ID)" DataField='title' HeaderStyle-HorizontalAlign="left"
                                            ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                            HeaderText="Required" DataField='required' HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                            HeaderText="Due Date" DataField='duedate' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center" />
                                        <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_1"
                                            HeaderText="Status" DataField='status' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="div_header_700">
        Recurrence:
    </div>
    <div class="div_controls font_1">
        <br />
        <asp:Label ID="lblRecurrence" runat="server"></asp:Label>
    </div>
    <br />
    <div class="div_header_700">
        Prerequisite(s):
    </div>
    <div class="table_150">
        <br />
        <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" 
            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
            AutoGenerateColumns="False">
            <RowStyle CssClass="record"></RowStyle>
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="width_600"  ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <table >
                            <tr>
                                <td class="width_600">
                                    <%#Eval("c_curriculum_text")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="div_header_700">
        Equivalancy(ies):
    </div>
    <div class="table_150">
        <br />
        <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None"
            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
            AutoGenerateColumns="False">
            <RowStyle CssClass="record"></RowStyle>
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td class="width_600">
                                    <%#Eval("c_curriculum_text")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="div_header_700">
        Fullfilment(s):
    </div>
    <div class="table_150">
        <br />
        <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None"
            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server"
            AutoGenerateColumns="False">
            <RowStyle CssClass="record"></RowStyle>
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td class="width_600">
                                    <%#Eval("c_curriculum_text")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOr" runat="server" Text="-or-"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
     <div class="div_header_700">
        &nbsp;
    </div>
</asp:Content>

