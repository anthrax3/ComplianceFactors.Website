<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samcmp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Catalog.samcmp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
            <%=LocalResources.GetLabel("app_manage_training_text")%>:
        </div>
        <br />
        <br />
        <div class="table_td_300">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <a href="Documents/samdimp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_documents_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="Instructor/samip-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_instructors_text")%></a>
                    </td>
                    <td>
                        <a href="Locations/samlimp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_locations_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="Curriculum/sascp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_curriculam_text")%></a>
                    </td>
                    <td>
                        <a href="Materials/sammimp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_materials_text")%></a>
                    </td>
                    <td>
                        <a href="Facilities/samfimp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_facilities_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="/SystemHome/Catalog/Course/sastcp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_courses_text")%></a>
                    </td>
                    <td>
                        <a href="Resources/samrimp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_resources_text")%></a>
                    </td>
                    <td>
                        <a href="Rooms/samroimp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_rooms_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="MassEnrollment/samep-01.aspx">
                            <%=LocalResources.GetLabel("app_mass_enrollment_text")%></a>
                    </td>
                    <td>
                        <a href="Approvals/samamp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_approvals_queue_text")%></a>
                    </td>
                    <td>
                        <a href="Waitlist/samwmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_waitlists_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="AssignmentGroups/samagmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_assignment_groups_text")%></a>
                    </td>
                    <td>
                        <a href="AssignmentRules/samarmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_assignment_rules_text")%></a>
                    </td>
                    <td>
                        <a href="Audiences/samaudmp-01.aspx">
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
                        <a href="Completion/samcsp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_completions_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="MassCompletions/samcp-01.aspx">
                            <%=LocalResources.GetLabel("app_mass_completions_text")%></a>
                    </td>
                    <td>
                        <a href="UpdateCurriculumStatuses/saucsp-01.aspx">
                            <%=LocalResources.GetLabel("app_update_curriculum_statuses_text")%>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="MassRemoval/samremp-01.aspx">
                            Mass Removal
                        </a>
                    </td>
                </tr>
                <%-- <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_programs_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="Category/samccmp-01.aspx">
                            <%=LocalResources.GetLabel("app_manage_categories_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_import_aicc_scorm_package_text")%>
                        </a>
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
                            <%=LocalResources.GetLabel("app_manage_packages_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_bundles_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_exams_text")%>
                        </a>
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
                            <%=LocalResources.GetLabel("app_manage_surveys_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_checklists_text")%>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <%=LocalResources.GetLabel("app_manage_tasks_text")%>
                        </a>
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
                            <%=LocalResources.GetLabel("app_manage_requests_text")%>
                        </a>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>--%>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
