<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="osha301.aspx.cs" Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.osha301" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
        body
        {
            width: 1000px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 600px;
            
        }
         img[src*="OpType=ReportImage&ResourceStreamID=Blank.gif"]
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <asp:ScriptManager ID="aa" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rvMIRIS" runat="server"  DocumentMapCollapsed="true" 
            Width="99%" Height="596px"
            ShowDocumentMapButton="false"  ExportContentDisposition="AlwaysInline">
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
