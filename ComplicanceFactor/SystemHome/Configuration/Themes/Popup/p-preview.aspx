<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="p-preview.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Themes.Popup.p_preview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/querystring-0.9.0.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 502px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 210px;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript">
        //location search popup
        $(document).ready(function () {
            //alert(1);
            var logoId = $.QueryString("imgId");
            var url = '../Logo/' + logoId;
            $('#imgLogo').attr('src',url);
            });
     </script>
     <div class="align_center">
            <img id="imgLogo"  class="align_center"  alt="Logo"/>
     </div>
</asp:Content>
