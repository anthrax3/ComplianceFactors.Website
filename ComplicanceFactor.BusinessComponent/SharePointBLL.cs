using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;

namespace ComplicanceFactor.BusinessComponent
{
    public class SharePointBLL
    {
        public const string spServicesUrl = "http://74.208.220.228:8090/appdev/Documents to Catalog/";
        public static void UploadFileToSharePoint(string UploadedFilePath,
      string SharePointPath)
        {
            WebResponse response = null;

            try
            {
                // Create a PUT Web request to upload the file.
                WebRequest request = WebRequest.Create(SharePointPath);

                request.Credentials = new System.Net.NetworkCredential("darrick", "A1b2c3d4", "U17216392");
                request.Method = "PUT";

                // Allocate a 1 KB buffer to transfer the file contents.
                // You can adjust the buffer size as needed, depending on
                // the number and size of files being uploaded.
                byte[] buffer = new byte[1024];

                // Write the contents of the local file to the
                // request stream.
                using (Stream stream = request.GetRequestStream())
                using (FileStream fsWorkbook = File.Open(UploadedFilePath,
                    FileMode.Open, FileAccess.Read))
                {
                    int i = fsWorkbook.Read(buffer, 0, buffer.Length);

                    while (i > 0)
                    {
                        stream.Write(buffer, 0, i);
                        i = fsWorkbook.Read(buffer, 0, buffer.Length);
                    }
                }

                // Make the PUT request.
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                response.Close();
            }
        }
     
    }
}
