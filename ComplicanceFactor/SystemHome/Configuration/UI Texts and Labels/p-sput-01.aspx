<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-sput-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.UI_Texts_and_Labels.p_sput_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            /*width: 960px;*/
            width: 650px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 450px;
        }
    </style>
    <div>
        <div class="div_header_650">
            UI Text Preview:
        </div>
        <br />
        <asp:Label ID="lblPreview" runat="server"></asp:Label>
    </div>
</asp:Content>
