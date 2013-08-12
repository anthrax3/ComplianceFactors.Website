<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="p-sapag-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.AssignmentGroups.Popup.p_sapag_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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
    <script type="text/javascript">

        $(function () {
            $('#<%=gvsearchDetails.ClientID %>')
			.tablesorter({ headers: { 2: { sorter: false}} });

        });       
    </script>
    <div id="content">
    <div class="div_header_popup_1">
        Assignment Group View:
    </div>
    <div class="div_header_long">
        <%= LocalResources.GetLabel("app_my_learning_history_text")%>:
        <div class="right div_padding_10">
            <asp:Button ID="btnPrintPdf" runat="server" Text="Print PDF"/>
            <asp:Button ID="btnExportExcel" runat="server" Text="Export Excel"/>
        </div>
        <div class="clear">
        </div>
    </div>
    <br />
    <div>
        <table cellpadding="0" cellspacing="0" class="paging_popup_1">
            <tr>
                <td align="left">
                    <asp:Button ID="btnHeaderFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                        OnClick="btnHeaderFirst_Click" />
                    <asp:Button ID="btnHeaderPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                        OnClick="btnHeaderPrevious_Click" />
                    <asp:Button ID="btnHeaderNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                        OnClick="btnHeaderNext_Click" />
                    <asp:Button ID="btnHeaderLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                        OnClick="btnHeaderLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblHeaderResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
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
                    <asp:Label ID="lblHeaderPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                    <asp:TextBox ID="txtHeaderPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblHeaderPageOf" runat="server" />
                    <asp:Button CssClass="cursor_hand" ID="btnHeaderGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                        OnClick="btnHeaderGoto_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvsearchDetails" CellPadding="0" CellSpacing="0" CssClass="gridview_popup_1 tablesorter"
            runat="server" EmptyDataText="No result found." 
            AutoGenerateColumns="False" AllowPaging="true"
            EmptyDataRowStyle-CssClass="empty_row" DataKeyNames="s_category_system_id_pk"
            PagerSettings-Visible="false" PageSize="10">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_3" ItemStyle-CssClass="gridview_row_width_3"
                    HeaderText="Last Name" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="First Name" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Middle Name" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="UserName" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Employee Id" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Hire Date" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Domain" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Type" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Country" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                 <asp:BoundField HeaderStyle-CssClass="gridview_row_width_4" ItemStyle-CssClass="gridview_row_width_4"
                    HeaderText="Job Title" DataField=''
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div>
        <table cellpadding="0" cellspacing="0" class="paging_popup_1">
            <tr>
                <td align="left">
                    <asp:Button ID="btnFooterFirst" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_first_button_text %>"
                        OnClick="btnFooterFirst_Click" />
                    <asp:Button ID="btnFooterPrevious" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_previous_button_text %>"
                        OnClick="btnFooterPrevious_Click" />
                    <asp:Button ID="btnFooterNext" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_next_button_text %>"
                        OnClick="btnFooterNext_Click" />
                    <asp:Button ID="btnFooterLast" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_last_button_text %>"
                        OnClick="btnFooterLast_Click" />
                </td>
                <td align="center">
                    <asp:Label ID="lblFooterResultPerPage" runat="server" Text="<%$ LabelResourceExpression: app_results_per_page_text %>"></asp:Label>
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
                    <asp:Label ID="lblFooterPage" runat="server" Text="<%$ LabelResourceExpression: app_page_text %>"></asp:Label>
                    <asp:TextBox ID="txtFooterPage" runat="server" CssClass="textbox_page_of_page" Text="1"></asp:TextBox>
                    <asp:Label ID="lblFooterPageOf" runat="server" />
                    <asp:Button CssClass="cursor_hand" ID="btnFooterGoto" runat="server" Text="<%$ LabelResourceExpression: app_go_to_button_text %>"
                        OnClick="btnFooterGoto_Click" />
                </td>
            </tr>
        </table>
    </div>
</div> 
</asp:Content>