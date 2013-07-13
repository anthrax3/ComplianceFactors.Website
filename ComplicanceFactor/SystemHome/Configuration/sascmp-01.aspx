<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="sascmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.sascmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
<%--    <style type="text/css">
        .div_header_grey_950
        {
            font-size: 14px;
            font-weight: 700;
            background-color: #D0D0D0;
            width: 950px;
            padding: 3px 0 3px 8px;
        }
    </style>--%>
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
    <div class="content_area_long">
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_manage_system_cofiguration_text")%>:
        </div>
        <br />
        <br />
        <div class="div_header_grey_950">
            UI Configuration:
        </div>
        <br />
        <div class="table_td_300">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <a href="/SystemHome/Configuration/Domains/samdmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_domains_text")%></a>
                    </td>
                    <td>
                        <a href="Splash Pages/samspmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_splash_pages_text")%></a>
                    </td>
                    <td>
                        <a href="Themes/samtmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_themes_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="Navigation/sasnmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_system_navigation_text")%></a>
                    </td>
                    <td>
                        <a href="Languages/salpmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_languages_text")%></a>
                    </td>
                    <td>
                        <a href="UI Texts and Labels/samuiltdp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_ui_labels_texts_dropdowns_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="DigitalMediaFiles/samdmmp-01.aspx"><%=LocalResources.GetLabel("app_manage_digital_media_files_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_grey_950">
            Data Integration:
        </div>
        <br />
        <div class="table_td_300">
            <table>
                <tr>
                    <td>
                        <a href="HRISIntegration/samhrismp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_hris_integration_text")%></a>
                    </td>
                    <td>
                        <a href="Data Imports/samdimpmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_date_imports_text")%></a>
                    </td>
                    <td>
                        <a href="DataExports/samdexpmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_data_exports_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_grey_950">
            eLearning Integration:
        </div>
        <br />
        <div class="table_td_300">
            <table>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_aicc_wrappers_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_aicc_scorm_content_player_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_content_servers_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_grey_950">
            Notifications and Reports:
        </div>
        <br />
        <div class="table_td_300">
            <table>
                <tr>
                    <td>
                        <a href="Notifications/samntmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_notifications_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_reports_text")%></a>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="div_header_grey_950">
            System Values:
        </div>
        <br />
        <div class="table_td_300">
            <table>
                <tr>
                    <td>
                        <a href="EmployeeTypes/sametmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_employee_types_text")%></a>
                    </td>
                    <td>
                        <a href="MaterialTypes/sammtmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_material_types_text")%></a>
                    </td>
                    <td>
                        <a href="ResourceTypes/samrtmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_resources_types_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="DeliveryTypes/samdtmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_delivery_types_text")%></a>
                    </td>
                    <td>
                        <a href="DocumentTypes/samdoctmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_document_types")%></a>
                    </td>
                    <td>
                        <a href="CurriculumTypes/samctmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_curriculum_types_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="InstructorTypes/samitmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_instructors_types_text")%></a>
                    </td>
                    <td>
                        <a href="FacilityTypes/samftmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_facility_types_text")%></a>
                    </td>
                    <td>
                        <a href="RoomTypes/samrotmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_room_types_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="GradingSchemes/samgsmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_grading_schemes_text")%></a>
                    </td>
                    <td>
                        <a href="CompletionStatuses/samcsmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_completion_statuses_text")%></a>
                    </td>
                    <td>
                        <a href="CurriculumStatuses/samcsmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_curriculum_statuses_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="ApprovalWorkflows/samawmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_approval_workflow_text")%></a>
                    </td>
                    <td>
                        <a href="Holiday Schedules/samhdmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_holiday_schedules_text")%></a>
                    </td>
                    <td>
                        <a href="Weekday Schedules/samwdmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_weekday_schedules_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="../Catalog/Category/samccmp-01.aspx">Manage Catalog Categories</a>
                    </td>
                    <td>
                        <a href="BackgroundJobs/sambjmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_background_jobs_text")%></a>
                    </td>
                    <td>
                        <a>Manage Data Purging/Archiving</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <%--<div class="div_header_grey_950">
            <br />
        </div>
        <br />
        <div class="table_td_300">
            <table>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_security_roles_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_naming_converstions_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_mail_server_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_vls_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_ecommerce_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_audit_log_tetxt")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_system_information_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_licensing_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_sso_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_esignature_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_password_login_settings_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_audiences_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_extended_enterprise_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_pricing_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_program_types_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_license_types_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_custom_fields_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_localization_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_approvals_text")%></a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_import_aicc_scorm_library_text")%></a>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>--%>
    </div>
</asp:Content>
