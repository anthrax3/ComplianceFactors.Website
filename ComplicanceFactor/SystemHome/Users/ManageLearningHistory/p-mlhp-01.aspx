<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-mlhp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Users.ManageLearningHistory.p_mlhp_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 1010px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 550px;
        }
    </style>
    <script type="text/javascript">
        function CheckScore(sender, args) {
            var gridCompletion = document.getElementById('<%=gvLearningHistory.ClientID %>');
            for (var i = 1; i < gridCompletion.rows.length; i++) {
                var inputs = gridCompletion.rows[i].getElementsByTagName('input');
                if (inputs[1].type == "text") {
                    if (inputs[1].value > 100) {
                        args.IsValid = false;
                        break;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            var userId = document.getElementById('<%=hdEditUser.ClientID %>').value
            //Add manager
            $("#<%=btnAddCompletion.ClientID %>").fancybox({
                'type': 'iframe',
                'titlePosition': 'over',
                'titleShow': true,
                'showCloseButton': true,
                'scrolling': 'yes',
                'autoScale': false,
                'autoDimensions': false,
                'helpers': { overlay: { closeClick: false} },
                'width': 980,
                'height': 200,
                'margin': 0,
                'padding': 5,
                'overlayColor': '#000',
                'overlayOpacity': 0.7,
                'hideOnOverlayClick': false,
                'href': '../AddCompletion/p-samcp-01.aspx?userId=' + userId,
                'afterClose': function () {
                    location.reload();
                    return;
                },
                'onComplete': function () {
                    $('#fancybox-frame').load(function () {
                        $('#fancybox-content').height($(this).contents().find('body').height() + 20);
                        var heightPane = $(this).contents().find('#content').height();
                        $(this).contents().find('#fancybox-frame').css({
                            'height': heightPane + 'px'

                        })
                    });
                }
            });
        });           

    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hdEditUser" runat="server" />
    <div class="content_area_long" id="content">
        <asp:ValidationSummary class="validation_summary_error" ID="vs_samcp_score" runat="server"
            ValidationGroup="samcp_score"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvValidateScore" EnableClientScript="true" ClientValidationFunction="CheckScore"
            ValidationGroup="samcp_score" runat="server" ErrorMessage="Score does not exceed 100">&nbsp;</asp:CustomValidator>
        <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
        </div>
        <div class="div_header_1005">
            My Learning History:
            <div class="right div_padding_10">
                <asp:Button ID="btnAddCompletion" runat="server" Text="Add Completion" CssClass="cursor_hand" />
            </div>
        </div>
        <br />
        <div class="clear">
        </div>
        <div class="div_controls_from_left font_1">
            <asp:GridView ID="gvLearningHistory" CellPadding="0" CellSpacing="0" runat="server"
                EmptyDataText="No result found" GridLines="Both" AutoGenerateColumns="False"
                EmptyDataRowStyle-CssClass="empty_row" PagerSettings-Visible="false" DataKeyNames="t_transcript_user_id_fk,t_transcript_course_id_fk,t_transcript_delivery_id_fk"
                OnRowDataBound="gvLearningHistory_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_7" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_3" HeaderText="Course Title (ID)" DataField='title'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderText="Completion Date" HeaderStyle-BackColor="LightGray"
                        HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2">
                        <ItemTemplate>
                            <asp:CalendarExtender ID="ceCompletionDate" runat="server" Format="MM/dd/yyyy" TargetControlID="txtCompletionDate">
                            </asp:CalendarExtender>
                            <asp:TextBox ID="txtCompletionDate" class="CompletionDate" Text='<%# Eval("date") %>'
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_4">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlStatus" DataTextField="s_status_name" DataValueField="s_status_id_pk"
                                runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Score" HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="gridview_row_width_1"
                        ItemStyle-CssClass="gridview_row_width_4" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtScore" Text='<%# Eval("score") %>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_4"
                        HeaderText="Completion Date" DataField='date'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                    <%--<asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Status" DataField='status' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                    <%-- <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" ItemStyle-CssClass="gridview_row_width_2"
                        HeaderText="Score" DataField='score' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:BoundField HeaderStyle-CssClass="gridview_row_width_1" HeaderStyle-BackColor="LightGray"
                        ItemStyle-CssClass="gridview_row_width_2" HeaderText="Delivery" DataField='deliveryType'
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="div_padding_40">
            <asp:Button ID="btnSaveChanges" runat="server" ValidationGroup="samcp_score" CssClass="cursor_hand"
                Text="Save Changes" OnClick="btnSaveChanges_Click" />
        </div>
        <br />
        <div class="div_header_1005">
            &nbsp;
        </div>
    </div>
</asp:Content>
