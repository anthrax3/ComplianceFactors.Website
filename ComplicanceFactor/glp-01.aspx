<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true"
    CodeBehind="glp-01.aspx.cs" Inherits="ComplicanceFactor.glp_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
   <script type="text/javascript">

       $(document).ready(function () {
           var str = location.href.toLowerCase();

           $('.navwrap li a').each(function () {
               if (str.indexOf(this.href.toLowerCase()) > -1) {

                   $("li.activated").removeClass("activated");
                   $(this).parent().addClass("activated");
               }
           });
           $('li.activated').parents().each(function () {

               if ($(this).is('li')) {
                   $(this).addClass("activated");
               }
           });


       })
    </script>
    <div class="content_area">
        <div class="home_content">
         
            <br /> 
           <%= LocalResources.GetText("wp_welcome_content")%>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
