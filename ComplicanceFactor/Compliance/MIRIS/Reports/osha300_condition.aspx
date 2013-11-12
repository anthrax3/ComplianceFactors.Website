<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="osha300_condition.aspx.cs"
MasterPageFile="~/Empty.Master" Inherits="ComplicanceFactor.Compliance.MIRIS.Reports.osha300_condition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Src="dynamicsearch.ascx" TagName="dynamicsearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
 <link href="../../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
     <script src="../../../Scripts/jquery.fancybox.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <script src="../../../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <link href="../../../Scripts/jquery.fancybox.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
       body
        {
            width: 1000px !important;
            margin: 0;
            font-family: Arial, Sans-Serif;
            font-size: 14px;
            height: 600px;
             overflow-x:hidden;
        }
    </style>
   
   <script type="text/javascript">

     
       function generate(url) {
          
           var page = $.QueryString("page");
           var h = url;
           var width = 1400;
           var height = 700;

           $.fancybox({
               'type': 'iframe',
               'titlePosition': 'over',
               'titleShow': true,
               'showCloseButton': true,
               'scrolling': 'yes',
               'autoScale': false,
               'autoDimensions': false,
               'helpers': { overlay: { closeClick: false} },
               'width': width,
               'height': height,
               'margin': 0,
               'padding': 0,
               'overlayColor': '#000',
               'overlayOpacity': 0.7,
               'hideOnOverlayClick': false,
               'href': h,
               'onComplete': function () {
                   $.fancybox.showActivity();

                   $('#fancybox-frame').load(function () {

                       $.fancybox.hideActivity();
                       $('#fancybox-content').height($(this).contents().find('body').height() + 120);
                       var heightPane = $(this).contents().find('#content').height() + 100;
                       $(this).contents().find('#fancybox-frame').css({
                           'height': heightPane + 'px'

                       })
                   });

               }

           });
       }

   </script>
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
      <div id="content" style="width:100%;">
        <asp:Panel ID="pnlDefault" runat="server"  Width="100%">
            <div class="div_header_popup_1" style="width:980px;">
                Search:
            </div>
           <br />
         
            <div class="div_controls font_1">
                <table>
                  <uc1:dynamicsearch ID="dynamicsearch1" runat="server" />
                    
                   <tr>
                   <td colspan="4" align="right">
                   
                       <asp:Button ID="btnGenerate" 
                            runat="server" Text="Generate!" onclick="btnGenerate_Click" />
                   </td>
                   </tr>
                </table>
            </div>

        </asp:Panel>
    </div>
</asp:Content>