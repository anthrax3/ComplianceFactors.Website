<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tcmtp-01.aspx.cs" Inherits="ComplicanceFactor.Training.tcmtp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_training').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_training').addClass('selected');
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
                        <a href="tcmdmp-01.aspx"><%=LocalResources.GetLabel("app_manage_deliveries_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/Instructor/samip-01.aspx?page=training"><%=LocalResources.GetLabel("app_manage_instructors_text")%></a>
                        
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
                       <a href="../SystemHome/Catalog/Completion/samcsp-01.aspx"><%=LocalResources.GetLabel("app_manage_roster_text")%></a>
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
                        <a href="../SystemHome/Catalog/Waitlist/samwmp-01.aspx"><%=LocalResources.GetLabel("app_manage_waitlists_text")%></a>
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
                        <a href="../SystemHome/Catalog/MassEnrollment/samep-01.aspx"><%=LocalResources.GetLabel("app_mass_enrollments_text")%></a>
                    </td>
                    <td>
                        <a href="../SystemHome/Catalog/MassCompletions/samcp-01.aspx"><%=LocalResources.GetLabel("app_mass_completions_text")%></a>
                    </td>
                    <td>
                       <a href="../SystemHome/Catalog/UpdateCurriculumStatuses/saucsp-01.aspx"><%=LocalResources.GetLabel("app_update_curriculum_statuses_text")%></a>
                    </td>
                </tr>

            </table>
            <br />
        </div>
    </div>
</asp:Content>
