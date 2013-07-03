<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="csveojt-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.SiteView.Ojt.csveojt_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function confirmStatus() {
            if (confirm('Are you sure?') == true)
                return true;
            else
                return false;

        }

        $(document).ready(function () {
            $('#app_nav_compliance').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_compliance').addClass('selected');
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtStartTime.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtStartTime.ClientID %>").click(
			function () {
			    $("#<%=txtStartTime.ClientID %>")[0].focus();
			}
		);
        });
    </script>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('#<%=txtStartTime.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });
            });
        })(jQuery);
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtEndTime.ClientID %>").watermark("HH:MM AM/PM");
            $("#<%=txtEndTime.ClientID %>").click(
			function () {
			    $("#<%=txtEndTime.ClientID %>")[0].focus();
			}
		);
        });
    </script>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('#<%=txtEndTime.ClientID %>').timepicker({ dropdown: false, timeFormat: 'h:mm p' });
            });
        })(jQuery);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary class="validation_summary_error" ID="vs_csveojt" runat="server"
        ValidationGroup="csveojt"></asp:ValidationSummary>
    <div id="divSuccess" runat="server" class="msgarea_success" style="display: none;">
    </div>
    <div id="divError" runat="server" class="msgarea_error" style="display: none;">
    </div>
    <div class="content_area_long">
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnHeaderSaveFieldNotes" ValidationGroup="csveojt" CssClass="cursor_hand"
                            runat="server" Text="Save FieldNotes" OnClick="btnHeaderSaveFieldNotes_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnHeaderReset" runat="server" CssClass="cursor_hand" Text="Reset"
                            OnClick="btnHeaderReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnHeaderCancel" runat="server" Text="Cancel"
                            OnClick="btnHeaderCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            On the Job Training:
        </div>
        <br />
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr style="display: none">
                    <td>
                        OJT Id:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ValidationGroup="csveojt"
                            ControlToValidate="txtTitle" ErrorMessage="please Enter Title">&nbsp; </asp:RequiredFieldValidator>
                        * Title:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ValidationGroup="csveojt"
                            ControlToValidate="txtLocation" ErrorMessage="Please Enter Location">&nbsp; </asp:RequiredFieldValidator>
                        * Location:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ValidationGroup="csveojt"
                            ControlToValidate="txtFieldDescription" ErrorMessage="Please Enter Description">&nbsp; </asp:RequiredFieldValidator>
                        * description:
                    </td>
                    <td class="align_left" colspan="6">
                        <textarea id="txtFieldDescription" runat="server" class="txtInput_long" rows="3"
                            cols="100"></textarea>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td align="right">
                        OJT Number:
                    </td>
                    <td class="align_left">
                        <asp:Label ID="lblOjtNumber" runat="server" CssClass="textbox_long"></asp:Label>
                        <%--<asp:TextBox ID="txtOjtNumber" CssClass="textbox_long" runat="server"></asp:TextBox>--%>
                    </td>
                    <td>
                        Date:
                    </td>
                    <td>
                        <asp:CalendarExtender ID="ceTimeDateNotified" Format="MM/dd/yyyy" TargetControlID="txtDate"
                            runat="server">
                        </asp:CalendarExtender>
                        <asp:TextBox ID="txtDate" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Duration:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDuration" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Start Time:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtStartTime" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        End Time:
                    </td>
                    <td>
                        <%--<MKB:TimeSelector ID="EndTime" CssClass="timer" DisplaySeconds="false" runat="server"
                            Date="">
                        </MKB:TimeSelector>--%>
                        <asp:TextBox ID="txtEndTime" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Type:
                    </td>
                    <td>
                        <asp:TextBox ID="txtType" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Harm Title:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtHarmTitle" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Harm Number:
                    </td>
                    <td>
                        <asp:TextBox ID="txtHarmNumber" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Frequency:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrequency" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Other:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtOthers" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Safety Brief:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkIsSafety" runat="server" />
                    </td>
                    <td>
                        Harm Related:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkIsHarm" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Trainer:
                    </td>
                    <td class="align_left">
                        <asp:TextBox ID="txtTrainer" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        Certification Related:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkIsCertification" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Is Acknowledge
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkIsAcknowledge" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
        <div class="div_header_long">
            Attachment(s):
        </div>
        <br />
        <br />
        <div class="div_padding_40 div_controls_from_left">
            <div>
                <asp:GridView ID="gvOjtAttachments" Width="530px" GridLines="None" CellPadding="0"
                    CellSpacing="0" ShowHeader="false" ShowFooter="false" DataKeyNames="sv_file_path,sv_file_name,sv_ojt_attachments_id_pk"
                    runat="server" AutoGenerateColumns="False" OnRowCommand="gvOltAttachments_RowCommand"
                    AllowSorting="True">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_7" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFileName" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    runat="server" Text='<%#Eval("sv_file_name") %>' CssClass="cursor_hand"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="gridview_row_width_1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnRemoveFiles" OnClientClick="return confirmStatus();" CommandName="Remove"
                                    runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    Text="Remove" CssClass="cursor_hand" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="align_left">
                        <asp:Button CssClass="cursor_hand" ID="btnAddAttachment" runat="server" Text="Attachment" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            &nbsp;
        </div>
        <br />
        <br />
        <br />
        <div>
            <table cellpadding="0" cellspacing="0" class="paging">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnFooterSaveFieldNotes" ValidationGroup="csveojt" CssClass="cursor_hand"
                            runat="server" Text="Save FieldNotes" OnClick="btnFooterSaveFieldNotes_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnFooterReset" runat="server" CssClass="cursor_hand" Text="Reset"
                            OnClick="btnFooterReset_Click" />
                    </td>
                    <td align="right">
                        <asp:Button CssClass="cursor_hand" ID="btnFooterCancel" runat="server" Text="Cancel"
                            OnClick="btnFooterCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:ModalPopupExtender ID="mpeAttachment" runat="server" TargetControlID="btnAddAttachment"
            PopupControlID="pnlUploadFile" BackgroundCssClass="transparent_class" DropShadow="false"
            PopupDragHandleControlID="pnlUploadFileHeading" OkControlID="imgClose" OnOkScript="cleartext();"
            OnCancelScript="cleartext();" CancelControlID="btnUploadCancel">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hdAttachments" runat="server" />
        <asp:Panel ID="pnlUploadFile" runat="server" CssClass="modalPopup_upload modal_popup_background" Style="display: none;
            padding-left: 0px;  padding-right: 0px;">
            <asp:Panel ID="pnlUploadFileHeading" runat="server" CssClass="drag_uploadpopup">
                <div>
                    <div class="uploadpopup_header">
                        <div class="left">
                            Upload File:
                            <asp:ImageButton ID="imgClose" CssClass="cursor_hand" Style="top: -15px; right: -15px;
                                z-index: 1103; position: absolute; width: 30px; height: 30px;" runat="server"
                                ImageUrl="~/Images/Zoom/fancy_close.png" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div>
                <br />
                <div class="uploadpanel">
                    Select File:
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="525" size="70" />
                    <br />
                    <br />
                    <br />
                    <div class="uploadbutton">
                        <asp:Button ID="btnUploadAttachements" runat="server" Text="Upload" CssClass="cursor_hand"
                            OnClick="btnUploadAttachements_Click" />
                    </div>
                    <asp:Button ID="btnUploadCancel" CssClass="cursor_hand" runat="server" Text="Cancel" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
