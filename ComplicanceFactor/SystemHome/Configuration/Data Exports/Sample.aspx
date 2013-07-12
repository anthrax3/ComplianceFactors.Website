<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.Data_Exports.Sample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Button ID="btnExportCSV" runat="server" Text="Export To CSV" OnClick = "ExportToCSV" />
 <asp:Button ID="btUpload" runat="server" Text="Upload" onclick="btUpload_Click"/>
 <asp:Button ID="Button1" runat="server" Text="read" onclick="Read_Click"/>
</asp:Content>
