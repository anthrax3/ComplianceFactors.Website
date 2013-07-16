using System;
using System.Web.UI;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Materials.Locale
{

    public partial class saaloc_01 : BasePage
    {
        #region "Private Member Variables"
        private string _pathMaterial = "~/SystemHome/Catalog/Materials/Upload/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide validation summary
            vssaaloc.Style.Add("display", "none");
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["localeText"]))
                {
                    lblLocaleHeading.Text = LocalResources.GetGlobalLabel("app_material_information_text") + " (" + Request.QueryString["localeText"] + ")";
                }
                //clear attachment session
                SessionWrapper.file_name = string.Empty;
                SessionWrapper.file_guid = string.Empty;

            }
            
            Attachment();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "create")
            {
                AddDataToLocale(Request.QueryString["localeid"], txtName.Text, txtDescriptoin.Value, Request.QueryString["localeText"], SessionWrapper.file_guid, SessionWrapper.file_name, SessionWrapper.Locale);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && Request.QueryString["mode"] == "edit")
            {
                SystemMaterial InsertLocale = new SystemMaterial();
                InsertLocale.s_material_locale_name = txtName.Text;
                InsertLocale.s_material_locale_description = txtDescriptoin.Value;
                InsertLocale.s_locale_id_fk = Request.QueryString["localeid"];
                InsertLocale.s_material_system_id_fk = Request.QueryString["editMaterialId"];

                try
                {
                    SystemMaterialBLL.InsertMaterialLocale(InsertLocale);
                }
                catch (Exception ex)
                {
                    //Log here
                    if (ConfigurationWrapper.LogErrors == true)
                    {
                        if (ex.InnerException != null)
                        {
                            Logger.WriteToErrorLog("saaloc-01.aspx(material)", ex.Message, ex.InnerException.Message);
                        }
                        else
                        {
                            Logger.WriteToErrorLog("saaloc-01.aspx(material)", ex.Message);
                        }
                    }
                }

            }
            //Close fancybox
            Page.ClientScript.RegisterStartupScript(this.GetType(), "fancyboxclose", "javascript:parent.document.forms[0].submit();parent.jQuery.fancybox.close();", true);
        }
        /// <summary>
        /// add datatable to locale
        /// </summary>
        /// <param name="s_locale_id_fk"></param>
        /// <param name="s_locale_name"></param>
        /// <param name="s_locale_description"></param>
        /// <param name="s_locale_text"></param>
        /// <param name="s_locale_file_guid"></param>
        /// <param name="s_locale_file_name"></param>
        /// <param name="dtTempLocale"></param>
        private void AddDataToLocale(string s_locale_id_fk, string s_locale_name, string s_locale_description, string s_locale_text, string s_locale_file_guid, string s_locale_file_name, DataTable dtTempLocale)
        {
            DataRow row;
            row = dtTempLocale.NewRow();
            row["s_locale_system_id_pk"] = Guid.NewGuid().ToString();
            row["s_locale_id_fk"] = s_locale_id_fk;
            row["s_locale_name"] = s_locale_name;
            row["s_locale_description"] = s_locale_description;
            row["s_locale_text"] = s_locale_text;
            row["s_locale_file_guid"] = s_locale_file_guid;
            row["s_locale_file_name"] = s_locale_file_name;
            dtTempLocale.Rows.Add(row);
        }

       

        protected void btnView_Click(object sender, EventArgs e)
        {
            Download();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.file_name = string.Empty;
            SessionWrapper.file_guid = string.Empty;
            Attachment();
        }
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.file_name))
            {
                divAttachment.Style.Add("display", "inline");
                btnAttachment.Style.Add("display", "none");
                lnkDownload.Text = SessionWrapper.file_name;
            }
            else
            {
                //show and hide view,edit,attchment and remove button
                divAttachment.Style.Add("display", "none");
                btnAttachment.Style.Add("display", "inline");
                lnkDownload.Text = string.Empty;
            }
        }
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":
                    return "image/png";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        private void Download()
        {
            string filePath = Server.MapPath(_pathMaterial + SessionWrapper.file_guid);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.file_name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = ReturnExtension(file.Extension.ToLower());
                        Response.WriteFile(file.FullName);
                        Response.End();
                        //if file does not exist
                    }
                    else
                    {
                        Response.Write("This file does not exist.");
                    }
                    //nothing in the URL as HTTP GET
                }
                else
                {
                    Response.Write("Please provide a file to download.");
                }
            }

        }

        protected void lnkAttachment_Click(object sender, EventArgs e)
        {
            Download();
        }
    }
}