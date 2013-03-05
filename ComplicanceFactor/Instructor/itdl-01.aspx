<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="itdl-01.aspx.cs" Inherits="ComplicanceFactor.Instructor.itdl_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_instructor').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_instructor').addClass('selected');
            return false;
        });
    });

    </script>
<br />
<br />
<center ><b><%=LocalResources.GetLabel("app_instructor_pod_mtodo_title")%> - <%=LocalResources.GetGlobalLabel("app_coming_soon")%> </b> </center>
<br />
<br />
<br />
<br />
</asp:Content>
