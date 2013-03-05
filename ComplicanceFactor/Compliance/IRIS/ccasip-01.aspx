<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ccasip-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.ccasip_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#app_nav_compliance').addClass('selected');
        // toggles the slickbox on clicking the noted link  
        $('.main_menu li a').hover(function () {

            $('.main_menu li a').removeClass('selected');
            $(this).addClass('active');

            return false;
        });
        $('.main_menu li a').mouseleave(function () {

            $('#app_nav_compliance').addClass('selected');
            return false;
        });
    });

    </script>
<br />
<br />
<center ><b><%=LocalResources.GetLocaleResourceText("app_ccasip_pagename")%> - <%=LocalResources.GetLocaleResourceText("app_coming_soon")%> </b> </center>
<br />
<br />
<br />
<br />
</asp:Content>
