<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sausr.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.UpdateCurriculumStatuses.p_sausr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 900px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function toggleSelection(source) {
            $("#gvsearchDetails input[name$='chkSelect']").each(function (index) {
                $(this).attr('checked', source.checked);
            });


        }
        function clearSelection() {
            if ($("#gvsearchDetails input[name$='chkSelect']").length == $("#gvsearchDetails input[name$='chkSelect']:checked").length) {
                $("#gvsearchDetails input[name$='chkSelectAll']").first().attr('checked', true);

            }
            else {
                $("#gvsearchDetails input[name$='chkSelectAll']").first().attr('checked', false);
            }
        }           
    </script>
    <script type="text/javascript" language="javascript">
        function validateCheckBoxes() {
            var isValid = false;
            var gridView = document.getElementById('<%= gvsearchDetails.ClientID %>');
            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            return true;
                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }
    </script>
    <div class="div_header_popup_1">
        Employee Search Results:
    </div>
    <div>
        <table cellpadding="0" cellspacing="0" class="paging_popup_1">
            <tr>
                <td align="left">
                    <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" Text="|<<First" runat="server"
                        OnClick="btnHeaderFirst_Click" />
                    <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" Text="<<Previous" runat="server"
                        OnClick="btnHeaderPrevious_Click" />
                    <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" Text="Next>>" runat="server"
                        OnClick="btnHeaderNext_Click" />
                    <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" Text="Last>>|" runat="server"
                        OnClick="btnHeaderLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Results Per Page:"></asp:Label>
                    <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblHeaderPage" runat="server" Text="Page"></asp:Label>
                    <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblHeaderPageOf" runat="server" Text="of 4" />
                    <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To"
                        OnClick="btnHeaderGoto_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_popup_1 tablesorter"
            runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="u_user_id_pk,e_enroll_status_name,e_curriculum_assign_percent_complete"
            OnRowCommand="gvsearchDetails_RowCommand" OnRowEditing="gvsearchDetails_RowEditing"
            OnPageIndexChanging="gvsearchDetails_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Last Name"
                    ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                    DataField="u_first_name" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee First Name"
                    ItemStyle-CssClass="gridview_row_width_3" HeaderStyle-HorizontalAlign="Center"
                    DataField="u_last_name" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" HeaderText="Employee Number"
                    ItemStyle-CssClass="gridview_row_width_2" HeaderStyle-HorizontalAlign="Center"
                    DataField="u_hris_employee_id" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" onclick="toggleSelection(this);" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" onclick="clearSelection();" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="right">
            <asp:Button ID="btnSaveSelected" runat="server" Text="Save Selected" OnClientClick="return validateCheckBoxes();"
                OnClick="btnSaveSelected_Click" />
        </div>
        <br />
        <table cellpadding="0" cellspacing="0" class="paging_popup_1">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" Text="|<<First" runat="server"
                        OnClick="btnFooterFirst_Click" />
                    <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" Text="<<Previous" runat="server"
                        OnClick="btnFooterPrevious_Click" />
                    <asp:Button ID="btnFooterNext" CssClass="cursor_hand" Text="Next>>" runat="server"
                        OnClick="btnFooterNext_Click" />
                    <asp:Button ID="btnFooterLast" CssClass="cursor_hand" Text="Last>>|" runat="server"
                        OnClick="btnFooterLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Results Per Page:"></asp:Label>
                    <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>Show All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label>
                    <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblFooterPageOf" runat="server" Text="of 4" />
                    <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To"
                        OnClick="btnFooterGoto_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_popup_1">
                 Employee Advanced Search:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            Employee Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Employee Number:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeNumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button CssClass="cursor_hand" ID="btnGoSearch" runat="server" Text="Go Search"
                                OnClick="btnGoSearch_Click" />
                        </td>
                        <td class="align_left">
                            <asp:Button CssClass="cursor_hand" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        </td>
                        <td class="align_right">
                            <asp:Button CssClass="cursor_hand" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
