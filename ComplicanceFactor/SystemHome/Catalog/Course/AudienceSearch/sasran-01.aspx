<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="sasran-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.Course.AudienceSearch.sasran_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 2: { sorter: false}} });

        });
       
    </script>
    <script type="text/javascript" language="javascript">
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
    </script>
    <script type="text/javascript" language="javascript">
        function confirmremove() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

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
    <script type="text/javascript">
        function resetall() {
            document.getElementById('<%=txtAudienceName.ClientID %>').value = '';
            document.getElementById('<%=txtAudienceId.ClientID %>').value = '';

            return false;
        }
    </script>
    <div id="content">
        <div class="div_header_popup_1">
            Audience Search Results:
        </div>
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging_popup_1">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="|<< First"
                            OnClick="btnHeaderFirst_Click" /><%--<%$ LabelResourceExpression: app_first_button_text %>--%>
                        <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<< Previous"
                            OnClick="btnHeaderPrevious_Click" /><%--<%$ LabelResourceExpression: app_previous_button_text %>--%>
                        <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="Next >>"
                            OnClick="btnHeaderNext_Click" /><%--<%$ LabelResourceExpression: app_next_button_text %>--%>
                        <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="Last >>|"
                            OnClick="btnHeaderLast_Click" /><%--<%$ LabelResourceExpression: app_last_button_text %>--%>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="Result Per page"></asp:Label>
                        <asp:DropDownList ID="ddlHeaderResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlHeaderResultPerPage_SelectedIndexChanged">
                            <%--<%$ LabelResourceExpression: app_results_per_page_text %>--%>
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
                        <asp:Label ID="lblHeaderPage" runat="server" Text="Page"></asp:Label><%--<%$ LabelResourceExpression: app_page_text %>--%>
                        <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblHeaderPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="Go To"
                            OnClick="btnHeaderGoto_Click1" /><%--<%$ LabelResourceExpression: app_go_to_button_text %>--%>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_popup_1 tablesorter"
                runat="server" EmptyDataText="No result found." AutoGenerateColumns="False" AllowPaging="true"
                EmptyDataRowStyle-CssClass="empty_row" DataKeyNames="u_audience_system_id_pk"
                PagerSettings-Visible="false" PageSize="5" OnPageIndexChanging="gvsearchDetails_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                        HeaderText="Audience Name" DataField='u_audience_name' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Audience Id" DataField='u_audience_id_pk' HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="gridview_row_width_1">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkSelectAll" onclick="toggleSelection(this);" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" onclick="clearSelection();" runat="server" />
                            <%-- <asp:HiddenField Visible="false" ID="hdnDescription" runat="server" Value='<%# Eval("u_domain_desc") %>' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="right">
            <asp:Button ID="btnSaveSelected" CssClass="cursor_hand" runat="server" Text="Save Selected"
                OnClientClick="return validateCheckBoxes();" OnClick="btnSaveSelected_Click" /><%--<%$ LabelResourceExpression: app_save_selected_button_text %>--%>
        </div>
        <br />
        <br />
        <div class="clear">
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="paging_popup_1">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="|<< First"
                            OnClick="btnFooterFirst_Click" /><%--<%$ LabelResourceExpression: app_first_button_text %>--%>
                        <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<< Previous"
                            OnClick="btnFooterPrevious_Click" /><%--<%$ LabelResourceExpression: app_previous_button_text %>--%>
                        <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="Next >>"
                            OnClick="btnFooterNext_Click" /><%--<%$ LabelResourceExpression: app_next_button_text %>--%>
                        <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="Last >>|"
                            OnClick="btnFooterLast_Click" /><%--<%$ LabelResourceExpression: app_last_button_text %>--%>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblFooterResultPerPage" runat="server" Text="Result Per Page"></asp:Label>
                        <asp:DropDownList ID="ddlFooterResultPerPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlFooterResultPerPage_SelectedIndexChanged">
                            <%--<%$ LabelResourceExpression: app_results_per_page_text %>--%>
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
                        <asp:Label ID="lblFooterPage" runat="server" Text="Page"></asp:Label><%--<%$ LabelResourceExpression: app_page_text %>--%>
                        <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                        <asp:Label ID="lblFooterPageOf" runat="server" />
                        <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="Go To"
                            OnClick="btnFooterGoto_Click1" /><%--<%$ LabelResourceExpression: app_go_to_button_text %>--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnGosearch">
            <div class="div_header_popup_1">
                Audience Search:
            </div>
            <br />
            <div class="div_controls font_1">
                <table>
                    <tr>
                        <td>
                            Audience Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAudienceName" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Audience Id:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAudienceId" CssClass="textbox_long" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="align_left">
                            <asp:Button ID="btnGosearch" CssClass="cursor_hand" Text="Go Search" runat="server"
                                OnClick="btnGosearch_Click" /><%--<%$ LabelResourceExpression: app_go_search_button_text %>--%>
                        </td>
                        <td class="align_left">
                            <asp:Button ID="btnReset" CssClass="cursor_hand" Text="Reset" OnClientClick="return resetall();"
                                runat="server" /><%--<%$ LabelResourceExpression: app_reset_button_text %>--%>
                        </td>
                        <td class="align_right">
                            <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" OnClientClick="javascript:document.forms[0].submit();parent.jQuery.fancybox.close();"
                                Text="Cancel" /><%--<%$ LabelResourceExpression: app_cancel_button_text %>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
