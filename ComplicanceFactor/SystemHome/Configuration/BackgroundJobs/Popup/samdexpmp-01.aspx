<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="samdexpmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.BackgroundJobs.Popup.samdexpmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 730px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 400px;
        }
    </style>
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
<div id="content">
    <div class="content_area_long">
       <div class="div_header_700">
            <%=LocalResources.GetLabel("app_single_file_manual_upload_text")%>:
        </div>
        <br />
        <div class="div_controls font_1">
            <table>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadHrisCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_hris_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadFacilitiesCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_facilities_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadRoomsCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_rooms_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadCoursesCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_courses_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadBaseCurriculamCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_base_curriculum_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadEnrollmentsCsvFile" runat="server" Text="<%$ LabelResourceExpression: app_download_enrollments_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_download_file_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:Button ID="btnDownloadLearningHistory" runat="server" Text="<%$ LabelResourceExpression: app_download_learning_history_csv_file_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_700">
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
                    <td style="padding-left: 60px">
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
                        <asp:TextBox ID="txtHris" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_hiris_text")%>
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkHris" CssClass="textbox_long" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=LocalResources.GetLabel("app_data_csv_file_name_text")%>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCatalogOfferings" CssClass="textbox_long" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <%=LocalResources.GetLabel("app_catalog_offering_text")%>:
                    </td>
                    <td class="align_left">
                        <asp:CheckBox ID="chkCatalogOfferings" CssClass="textbox_long" runat="server" />
                    </td>
                    <td>
                        &nbsp;
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
                        <asp:CheckBox ID="chkLearningHistory" CssClass="textbox_long" runat="server" />
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
                        <asp:DropDownList ID="ddlTimeConversion" CssClass="textbox_50" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="align_left" colspan="3">
                        <%=LocalResources.GetLabel("app_beginning_text")%>:&nbsp;&nbsp;<asp:TextBox ID="txtBegining"
                            CssClass="textbox_75" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnDisplayExportLogs" runat="server" Text="<%$ LabelResourceExpression: app_display_export_logs_button_text %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="align_left" colspan="2">
                        <asp:Button ID="btnSaveDataExportSftpInformation" runat="server" CssClass="cursor_hand"
                            Text="<%$ LabelResourceExpression: app_save_data_export_sftp_information_button_text %>" />
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
    </div>
</asp:Content>
