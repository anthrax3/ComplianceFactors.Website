<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tamtp-01.aspx.cs" Inherits="ComplicanceFactor.Administrator.tamtp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('#app_nav_admin').addClass('selected');
            // toggles the slickbox on clicking the noted link  
            $('.main_menu li a').hover(function () {

                $('.main_menu li a').removeClass('selected');
                $(this).addClass('active');

                return false;
            });
            $('.main_menu li a').mouseleave(function () {

                $('#app_nav_admin').addClass('selected');
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
                        <a href="../SystemHome/Catalog/Documents/samdimp-01.aspx"><%=LocalResources.GetLabel("app_manage_documents_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Instructor/samip-01.aspx"><%=LocalResources.GetLabel("app_manage_instructors_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Locations/samlimp-01.aspx"><%=LocalResources.GetLabel("app_manage_locations_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="../SystemHome/Catalog/Curriculum/sascp-01.aspx"><%=LocalResources.GetLabel("app_manage_curriculam_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Materials/sammimp-01.aspx"><%=LocalResources.GetLabel("app_manage_materials_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Facilities/samfimp-01.aspx"><%=LocalResources.GetLabel("app_manage_facilities_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="/SystemHome/Catalog/Course/sastcp-01.aspx"><%=LocalResources.GetLabel("app_manage_courses_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Resources/samrimp-01.aspx"><%=LocalResources.GetLabel("app_manage_resources_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Rooms/samroimp-01.aspx"><%=LocalResources.GetLabel("app_manage_rooms_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="../SystemHome/Catalog/MassEnrollment/samep-01.aspx"><%=LocalResources.GetLabel("app_manage_enrollments_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Approvals/samamp-01.aspx"><%=LocalResources.GetLabel("app_manage_approvals_queue_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Waitlist/samwmp-01.aspx"><%=LocalResources.GetLabel("app_manage_waitlists_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#"><%=LocalResources.GetLabel("app_manage_assignment_groups_text")%></a>
                    </td>
                    <td>
                        <a href="#"><%=LocalResources.GetLabel("app_manage_assignment_rules_text")%> </a>
                    </td>
                    <td>
                        <a><%=LocalResources.GetLabel("app_manage_audiences_text")%></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="../SystemHome/Catalog/Completion/samcsp-01.aspx"><%=LocalResources.GetLabel("app_manage_completions_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/MassCompletions/samcp-01.aspx"><%=LocalResources.GetLabel("app_mass_completions_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/UpdateCurriculumStatuses/saucsp-01.aspx"><%=LocalResources.GetLabel("app_update_curriculum_statuses_text")%></a>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
