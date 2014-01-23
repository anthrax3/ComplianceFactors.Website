<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tcmrp-01.aspx.cs" Inherits="ComplicanceFactor.Training.tcmrp_01" %>

<%@ Register src="../Compliance/MIRIS/Reports/mrp-01.ascx" tagname="mrp" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
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
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_training_reports_text")%><br />
        <br />
        <br />
    </div>
    <br />
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
    </div>
    <br />
    <div class="div_padding_10" id="div_MyReports" runat="server">
        <uc1:mrp ID="mrp1" runat="server" />
      
    </div>
    <br />
    <div class="div_header_long">
        <br />
    </div>
    <div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_training_reports_text")%>
        <br />
        <br />
    </div>
    </div>
</asp:Content>
