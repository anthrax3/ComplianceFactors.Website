<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true"
    CodeBehind="p-samdpv-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.Popup.p_samdpv_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 720px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 500px;
        }
    </style>
<div id="content">
    <div>
        <div class="uploadpopup_header">
            <div class="left">
                <%=LocalResources.GetLabel("app_add_digital_media_file_text")%>:
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div>
        <object classid="clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95">
            <param name="FileName" value="../Images/1919b655-81f7-4840-b3e3-85acf64ecf82.jpg"  />
        </object>       
    </div>
    </div>
</asp:Content>
