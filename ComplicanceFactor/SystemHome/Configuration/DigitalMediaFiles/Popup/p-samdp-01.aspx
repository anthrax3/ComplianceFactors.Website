<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p-samdp-01.aspx.cs" Inherits="ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.Popup.p_samdp_01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <object classid="clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921"codebase="http://download.videolan.org/pub/videolan/vlc/last/win32/axvlc.cab" width="500" height="280">
     <param name="quality" value="high" />
    <embed type="application/x-vlc-plugin" pluginspage="http://www.videolan.org" autoplay="yes" lop="no" width="700" height="480" runat="server"  ID="Video1"
    src="../Images/08b39814-01c9-4e20-9934-594c7e0d4c7b.wmv" value="../Images/08b39814-01c9-4e20-9934-594c7e0d4c7b.wmv" />
    </object>
    </div>
    </form>
</body>
</html>
