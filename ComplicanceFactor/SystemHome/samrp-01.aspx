<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="samrp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.samrp_01" %>

<%@ Register src="../Compliance/MIRIS/Reports/mrp-01.ascx" tagname="mrp" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
        <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_system_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
    </div>
    <div class="clear">
    </div>
    <div id="div_MyReports" class="div_padding_10">
       <uc1:mrp ID="mrp1" runat="server" />
<div class="clear">
        </div>
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
        <br />
    </div>
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_system_home_text")%>
        <br />
        <br />
    </div>
</asp:Content>
