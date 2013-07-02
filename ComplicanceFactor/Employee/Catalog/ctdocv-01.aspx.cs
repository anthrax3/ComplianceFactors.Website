using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using ComplicanceFactor.Common;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Employee.Catalog
{
    public partial class ctdocv_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                string brdCrumb = "<a href=/Employee/Catalog/qscr-01.aspx?keyword=" + SecurityCenter.EncryptText("") + ">" + " { " + LocalResources.GetGlobalLabel("app_quick_search_text") + "</a>" + " <a href=# > or </a>" + "<a href=/Employee/Catalog/ascp-01.aspx>" + LocalResources.GetGlobalLabel("app_advanced_search_text") + "</a>" + " <a href=# > or </a> " + "<a href=/Employee/Catalog/bchp-01.aspx>" + LocalResources.GetGlobalLabel("app_browse_text") + " } " + "Catalog" + "</a>";
                lblBreadCrumb.Text = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>" + " > " + brdCrumb + " > " + LocalResources.GetGlobalLabel("app_document_view_text");
                if (!string.IsNullOrEmpty(Request.QueryString["View"]))
                {
                    string View = SecurityCenter.DecryptText(Request.QueryString["View"]);
                    SystemDocuments document = new SystemDocuments();
                    DataSet dsDocument = SystemDocumentsBLL.GetDocument(View);
                    document = SystemDocumentsBLL.GetSingleDocument(View, dsDocument.Tables[0]);
                    ltlPreview.Text = "<iframe id='documentLoader' src=https://docs.google.com/viewer?url=" + Request.Url.Host.ToLower() + "/SystemHome/Catalog/Documents/Upload/" + document.s_documnet_attachment_file_guid + "&embedded=true width='722' height='500';/>";
                }



                //if ((type == "JPEG") || (type == "GIF") || (type == "PNG"))
                //{
                //    ltlPreview.Text = "<object data=../Images/" + filename + " width='722' height='500'/>";
                //}
                //else if ((type == "PDF") || (type == "DOC") || (type == "XLS") || (type == "PPT") || (type == "Other"))
                //{

                //}
                //else if ((type == "SWF") || (type == "MPEG") || (type == "MOV") || (type == "AVI") || (type == "WMA") || (type == "MP3"))
                //{
                //    ltlPreview.Text = "<object classid='clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921' codebase='http://download.videolan.org/pub/videolan/vlc/last/win32/axvlc.cab' width='722' height='500'> <param name='quality' value='high' /> <embed type='application/x-vlc-plugin' pluginspage='http://www.videolan.org' autoplay='yes' lop='no' width='722' height='500'   ID='Video1' src='../Images/ " + filename + "' value='../Images/ " + filename + "' /></object>";
                //}
            }
        }
    }
}