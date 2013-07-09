using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplicanceFactor.SystemHome.Configuration.DigitalMediaFiles.Popup
{
    public partial class p_samdp_01 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = Request.QueryString["fname"].ToString();
            string type = Request.QueryString["ftype"].ToString();

            string protocol = Request.Url.AbsoluteUri;
            int len = protocol.IndexOf(':');
            protocol = protocol.Substring(0, len);

            if ((type == "JPEG") || (type == "GIF") || (type == "PNG"))
            {
                ltlPreview.Text = "<object data=../Images/" + filename + " width='700' height='490'/>";
            }
            else if ((type == "PDF") || (type == "DOC") || (type == "XLS") || (type == "PPT") || (type == "Other"))
            {
                ltlPreview.Text = "<iframe id='documentLoader' src=https://docs.google.com/viewer?url=" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "&embedded=true width='700' height='490';/>";
            }
            else if ((type == "MPEG") || (type == "AVI") || (type == "MOV") || (type == "WMA") || (type == "MP3"))
            {
                ltlPreview.Text = "<object classid='clsid:E23FE9C6-778E-49D4-B537-38FCDE4887D8' codebase='http://download.videolan.org/pub/videolan/vlc/last/win32/axvlc.cab' type='application/x-oleobject' width='700' height='490'>  <param name='Src' value='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "'  /> <embed  pluginspage='http://www.videolan.org' autoplay='yes' lop='no' width='700' height='490'  ID='Video1' src='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "' type='application/x-vlc-plugin'  /></object>";
                //ltlPreview.Text = "<object classid='clsid:E23FE9C6-778E-49D4-B537-38FCDE4887D8' codebase='http://download.videolan.org/pub/videolan/vlc/last/win32/axvlc.cab' type='application/x-oleobject' width='700' height='490'>  <param name='Src' value='http://localhost:59207/SystemHome/Configuration/DigitalMediaFiles/Images/mov.mov'  /> <embed  pluginspage='http://www.videolan.org' autoplay='yes' lop='no' width='700' height='490'  ID='Video1' src='http://localhost:59207/SystemHome/Configuration/DigitalMediaFiles/Images/mov.mov' type='application/x-vlc-plugin'  /></object>";

                //ltlPreview.Text = "<object classid='clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921' codebase='http://download.videolan.org/pub/videolan/vlc/last/win32/axvlc.cab' type='application/x-oleobject' width='700' height='490'> <param name='Src' value='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "'  /> <embed  pluginspage='http://www.videolan.org' type='application/x-vlc-plugin' progid='VideoLAN.VLCPlugin.2' name='vlc' autoplay='yes' lop='no' width='700' height='490'  ID='Video1' src='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "'/></object>";
            }
            else if(type == "SWF")
            {
                ltlPreview.Text = "<object codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7' classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' type='application/x-oleobject' width='700' height='490'> <param name='src' value='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "'> <embed src='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "' type='application/x-shockwave-flash' pluginspage='http://www.adobe.com/go/getflashplayer' width='700' height='490'></embed></object>";
                
            }
            //else if (type == "AVI")
            //{
            //    ltlPreview.Text = "<object codebase='http://www.apple.com/qtactivex/qtplugin.cab' classid='clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6' type='application/x-oleobject' width='740' height='510'> <param name='src' value='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "'> <embed src='" + protocol + "://" + Request.Url.Host.ToLower() + "/SystemHome/Configuration/DigitalMediaFiles/Images/" + filename + "' type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/MediaPlayer/'></embed></object>";
            //}
            
        }

    }
}