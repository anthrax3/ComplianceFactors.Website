<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="tamrp-01.aspx.cs" Inherits="ComplicanceFactor.Administrator.tamrp_01" %>

<%@ Register Src="../Compliance/MIRIS/Reports/mrp-01.ascx" TagName="mrp" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_administrator_home_text")%><br />
        <br />
        <br />
    </div>
    <div class="div_header_long">
        <%=LocalResources.GetLabel("app_my_reports_text")%>:
    </div>
    <div class="div_padding_10" id="div_MyReports" runat="server">
        <uc1:mrp ID="mrp1" runat="server" />
        <div class="clear">
        </div>
    </div>
    <div>
        <div class="div_header_long">
        </div>
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_footer_administrator_home_text")%>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
