using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.Common;

namespace ComplicanceFactor.SystemHome.Catalog.Curriculum.GenerateFile
{
    public partial class sagf_01 : System.Web.UI.Page
    {
        #region
        private string _pathIcon = "~/SystemHome/Catalog/Curriculum/Icons/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(_pathIcon + SessionWrapper.c_curriculum_icon_uri);

            if (System.IO.File.Exists(filePath))
            {


                string strRequest = filePath;

                if (!string.IsNullOrEmpty(strRequest))
                {

                    FileInfo file = new System.IO.FileInfo(strRequest);

                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.c_curriculum_icon_uri_file_name + "\"");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = ReturnExtension(file.Extension.ToLower());
                        Response.WriteFile(file.FullName);
                        Response.End();
                        Response.Clear();


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

        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {

                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".png":

                    return "image/png";


                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".JPG":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream";

            }
        }
    }
}