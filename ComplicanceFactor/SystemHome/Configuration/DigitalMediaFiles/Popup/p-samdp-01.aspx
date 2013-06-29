<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p-samdp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.Popup.p_samdp_01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            width: 722px !important;
            margin: 0px 0 0 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 500px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
    
        
    
    <div>
   <%--<object classid="clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921"codebase="http://download.videolan.org/pub/videolan/vlc/last/win32/axvlc.cab" width="500" height="280">
     <param name="quality" value="high" />
    <embed type="application/x-vlc-plugin" pluginspage="http://www.videolan.org" autoplay="yes" lop="no" width="700" height="480" runat="server"  ID="Video1"
    src="../Images/Jellyfish.jpg" value="../Images/Jellyfish.jpg" />
    </object>--%>
    <%--<iframe id="documentLoader" src="https://docs.google.com/viewer?url=http://compliancefactors.com.lavender.arvixe.com/Compliance/MIRIS/Upload/Photo/df876a79-dc6a-4b65-b156-9f1bac58d73c.pdf&embedded=true" style="width: 70%; height: 400px;">--%>
   
  <%-- </iframe>--%>
   <asp:Literal ID="ltlPreview" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
