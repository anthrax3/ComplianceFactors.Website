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
    <div id="content">
        <%--<asp:Literal ID="ltlPreview" runat="server"></asp:Literal>--%>
        <%--<object width="480" height="385">
<param name="movie" value="http://www.youtube.com/v/XcugLsKDmRs&hl=en_US&fs=1&rel=0"></param>
<param name="allowFullScreen" value="true"></param>
<param name="allowscriptaccess" value="always"></param>
<embed src="http://www.youtube.com/v/XcugLsKDmRs&hl=en_US&fs=1&rel=0" 
  type="application/x-shockwave-flash" allowscriptaccess="always" 
  allowfullscreen="true" width="480" height="385"></embed>
</object>--%>

        
<object classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" type="application/x-oleobject" width="320" height="240">
   <param name="URL" value="<%= file_url %>" />
   <param name="enabled" value="True" />
   <param name="AutoStart" value="False" />
   <param name="PlayCount" value="3" />
   <param name="Volume" value="50" />
   <param name="balance" value="0" />
   <param name="Rate" value="1.0" />
   <param name="Mute" value="False" />
   <param name="fullScreen" value="False" />
   <param name="uiMode" value="full" />
</object>

    </div>
    </form>
</body>
</html>
