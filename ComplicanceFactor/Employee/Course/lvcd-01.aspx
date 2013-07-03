<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="lvcd-01.aspx.cs" Inherits="ComplicanceFactor.Employee.Course.lvcd_01" %>

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
   <div id="content">
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_course_details_text")%>:
        </div>
        <div class="table_150">
            <br />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblCourseTitle" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_revision_text")%>:
                        <asp:Label ID="lblRevision" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDeliveryType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <%=LocalResources.GetLabel("app_description_text")%>:<br />
                        <asp:Label ID="lblDescription" CssClass="font_normal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_approval_text")%>:
                        <asp:Label ID="lblApproval" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_manager_text")%>:
                        <asp:Label ID="lblManager" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_cost_text")%>:
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
                        <%=LocalResources.GetLabel("app_owner_text")%>:
                        <asp:Label ID="lblOwner" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_coordinator_text")%>:
                        <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_session_text")%>:
        </div>
        <div class="table_150">
            <asp:GridView ID="gvSession" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="c_session_system_id_pk"
                runat="server" AutoGenerateColumns="False" OnRowDataBound="gvSession_RowDataBound"
                EmptyDataRowStyle-CssClass="empty_row" EmptyDataText="<%$ LabelResourceExpression: app_no_result_found_text %>">
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="horizontal_line" colspan="3">
                                        <hr>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="gridview_row_width_350">
                                        <asp:Label ID="lblSession1" runat="server"></asp:Label>
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
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_recurrence_text")%>:
        </div>
        <div class="div_controls font_1">
            <br />
            <asp:Label ID="lblRecurrence" runat="server"></asp:Label>
        </div>
        <br />
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_prerequisite_text")%>:
        </div>
        <div class="table_150">
            <br />
            <asp:GridView ID="gvPrerequisites" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td class="width_600">
                                        <%#Eval("c_course_text") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="<%$ LabelResourceExpression: app_or_text %>"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_equivalancy_text")%>:
        </div>
        <div class="table_150">
            <br />
            <asp:GridView ID="gvEquivalencies" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td class="width_600">
                                        <%#Eval("c_course_text") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="<%$ LabelResourceExpression: app_or_text %>"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="div_header_700">
            <%=LocalResources.GetLabel("app_fullfilment_text")%>:
        </div>
        <div class="table_150">
            <br />
            <asp:GridView ID="gvFulfillments" RowStyle-CssClass="record" GridLines="None" CellPadding="0"
                CellSpacing="0" ShowHeader="false" ShowFooter="false" runat="server" AutoGenerateColumns="False">
                <RowStyle CssClass="record"></RowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="width_600" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td class="width_600">
                                        <%#Eval("c_course_text") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOr" runat="server" Text="<%$ LabelResourceExpression: app_or_text %>"></asp:Label>
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
    </div>
</asp:Content>
