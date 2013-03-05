<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ssdot-01.aspx.cs" Inherits="ComplicanceFactor.SuccessStories.ssdot_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
   <script type="text/javascript">

       $(document).ready(function () {

           var str = location.href.toLowerCase();

           $('.navwrap li a').each(function () {

               if (str.lastIndexOf(this.href.toLowerCase('/')) > -1) {

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

<br />
<br />
<center ><b><%=LocalResources.GetText("wp_nav_ss_pod_dot_content")%> - <%=LocalResources.GetGlobalLabel("app_coming_soon")%> </b> </center>
<br />
<br />
<br />
<br />
</asp:Content>
