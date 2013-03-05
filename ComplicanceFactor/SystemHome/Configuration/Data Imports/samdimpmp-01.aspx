<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samdimpmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Data_Imports.samdimpmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_system').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_system').addClass('selected');
                return false;
            });
        });

    </script>
    <br />
    <br />
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_single_file_manual_upload_text")%>:
        </div>
        <br />
        <div class=" div_controls font_1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                        
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectFacilitiesCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_facilities_csv_file_button_text %>" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_facilities_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleFacilitiesFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_sample_facilities_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectRoomCsvFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_rooms_csv_file_button_text %>" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_rooms_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleRoomFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_sample_rooms_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectCoursesCsvFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_select_courses_csv_file_button_text %>" />
                    </td>
                    <td colspan="2">
                        <%=LocalResources.GetLabel("app_sample_courses_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleCoursesFile" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_sample_courses_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectBaseCurriculamCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_base_curricula_csv_file_button_text %>" />
                    </td>
                    <td colspan="2">
                       <%=LocalResources.GetLabel("app_sample_base_curricula_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleBaseCurriculamFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_sample_base_curricula_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectEnrollmentsCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_enrollments_csv_file_button_text %>" />
                    </td>
                    <td colspan="2">
                       <%=LocalResources.GetLabel("app_sample_enrollments_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleEnrollmentsCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_sample_enrollments_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_upload_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSelectLearningHistoryCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_select_learning_history_csv_file_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="width_200">
                       <%=LocalResources.GetLabel("app_learning_history_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnSampleLearningHistoryCsvFile" CssClass="cursor_hand" runat="server"
                            Text="<%$ LabelResourceExpression: app_sample_learning_history_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_sftp_server_and_synchronization_info_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_sftp_server_uri_text")%>: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtSftpServerUri" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td style="padding-left: 110px">
                        &nbsp;
                    </td>
                    <td>
                       <%=LocalResources.GetLabel("app_sftp_server_port_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSftpServerPort" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_username_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_password_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_data_csv_file_name_text")%>: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnrollments" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_enrollments_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkEnrollments" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                       <%=LocalResources.GetLabel("app_data_csv_file_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLearningHistory" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                         <%=LocalResources.GetLabel("app_learning_history_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkLearningHistory" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_occurs_every_text")%>:
                    </td>
                    <td class="align_left" colspan="2">
                        <asp:TextBox ID="txtOccursEvery" CssClass="textbox_50" runat="server"></asp:TextBox>&nbsp;&nbsp;<%=LocalResources.GetLabel("app_days_text")%>
                        &nbsp;<%=LocalResources.GetLabel("app_at_text")%>
                        <asp:TextBox ID="txtHours" CssClass="textbox_75" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlHour" CssClass="textbox_50" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_left" colspan="3">
                        <%=LocalResources.GetLabel("app_beginning_text")%>:&nbsp;&nbsp;<asp:TextBox ID="txtBegining" CssClass="textbox_75" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Button ID="btnDisplayImportLogs" runat="server" Text="<%$ LabelResourceExpression: app_display_import_logs_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_left" colspan="2">
                        <asp:Button ID="btnSaveDataImportSftpInformation" runat="server" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_data_import_sftp_info_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnReset" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_reset_button_text %>" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="align_right">
                        <asp:Button ID="btnCancel" CssClass="cursor_hand" runat="server" Text="<%$ LabelResourceExpression: app_cancel_button_text %>" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_header_long">
            <br />
        </div>
    </div>
</asp:Content>
