<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="p-spcsr-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Curriculum.CourseSearch.p_spcsr_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 700px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 300px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 3: { sorter: false}} });

        });
        function toggleSelection(source) {
            $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']").each(function (index) {
                $(this).attr('checked', source.checked);
            });


        }
        function clearSelection() {
            if ($("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']").length == $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelect']:checked").length) {
                $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelectAll']").first().attr('checked', true);

            }
            else {
                $("#<%=gvsearchDetails.ClientID %> input[name$='chkSelectAll']").first().attr('checked', false);
            }
        }
        function confirmremove() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

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
                            return true;
                        }
                    }
                }
            }
            alert("Please select atleast one checkbox");
            return false;
        }
        function resetall() {
            document.getElementById('<%=txtCourseId.ClientID %>').value = '';
            document.getElementById('<%=txtCourseName.ClientID %>').value = '';
            return false;
        }
    </script>
    <div>
        <div class="div_header_700">
            Course Search Results
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging_700">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<<First"
                            OnClick="btnHeaderFirst_Click" />
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<<Previous"
                            OnClick="btnHeaderPrevious_Click" />
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="Next>>"
                            OnClick="btnHeaderNext_Click" />
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="Last>>|"
                            OnClick="btnHeaderLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
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
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To"
                            OnClick="btnHeaderGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_padding_25">
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="table_700 tablesorter"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" DataKeyNames="c_course_system_id_pk" PagerSettings-Visible="false"
                PageSize="5" OnPageIndexChanging="gvsearchDetails_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Course Name" DataField='c_course_title' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Course Id" DataField='c_course_id_pk' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_2" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Delivery Type" DataField='c_delivery_type_name' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkSelectAll" onclick="toggleSelection(this);" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" onclick="clearSelection();" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="right">
            <asp:Button ID="btnAddSelected" CssClass="cursor_hand" runat="server" Text="Add Selected"
                OnClientClick="return validateCheckBoxes();" OnClick="btnAddSelected_Click" />
        </div>
        <br />
        <br />
        <div class="clear">
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging_700">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="|<<First"
                            OnClick="btnFooterFirst_Click" />
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<<Previous"
                            OnClick="btnFooterPrevious_Click" />
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="Next>>"
                            OnClick="btnFooterNext_Click" />
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="Last>>|"
                            OnClick="btnFooterLast_Click" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>Show All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label>
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To"
                            OnClick="btnFooterGoto_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_700">
                Course Search:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            Course Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCourseName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Course Id:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCourseId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search !" runat="server"
                                OnClick="btnGosearch_Click" />
                        </td>
                        <td class="align_left">
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

