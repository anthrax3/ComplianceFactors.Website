<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ccmrp-01.aspx.cs" Inherits="ComplicanceFactor.Compliance.ccmrp_01"
    EnableEventValidation="true" %>

<%@ Register Src="MIRIS/Reports/mrp-01.ascx" TagName="mrp" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_area">
        <div class="content_area">
            <%= LocalResources.GetText("app_welcome_content_comp_my_reports_text")%><br />
            <br />
            <br />
        </div>
    </div>
    <br />
    <div>
        <div class="div_header_long">
            <%=LocalResources.GetLabel("app_my_reports_text")%>:
        </div>
        <br />
        <uc1:mrp ID="mrp1" runat="server" />
    </div>
    <br />
    <div class="div_header_long">
        &nbsp;
    </div>
    <br />
    <div class="content_area">
        <%= LocalResources.GetText("app_welcome_content_footer_comp_my_reports_text")%>
        <br />
        <br />
    </div>
</asp:Content>
