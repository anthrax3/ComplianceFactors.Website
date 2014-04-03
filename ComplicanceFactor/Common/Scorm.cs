using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using Ionic.Zip;

namespace ComplicanceFactor.Common
{
    public class Scorm
    {
        public static string UploadHandler(FileUpload scorm_package)
        {
            string status = "";
            string course_id = "";
            try
            {
                if (scorm_package.PostedFile.FileName.EndsWith(".zip"))
                {
                    course_id = Guid.NewGuid().ToString();
                    // set session variable so that parent pages catch it
                    SessionWrapper.c_course_system_id_pk = course_id;

                    // set default message; will be changed if something goes wrong...
                    status = "Course content uploaded and imported successfully.";

                    string base_path = "~/LMS/Courses/";
                    string filename = course_id + ".zip";
                    string zip_full_path = HttpContext.Current.Server.MapPath(base_path + filename);
                    string course_unpack_path = HttpContext.Current.Server.MapPath(base_path + course_id);
                    string ims_manifest_path = HttpContext.Current.Server.MapPath(base_path + course_id + "/imsmanifest.xml");

                    scorm_package.SaveAs(zip_full_path);

                    //Unzip course to course_id-named folder
                    using (ZipFile zip1 = ZipFile.Read(zip_full_path))
                    {
                        foreach (ZipEntry ez in zip1)
                        {
                            ez.Extract(course_unpack_path, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }

                    string scorm_schemaversion = "";
                    string scorm_coursetitle = "";
                    string scorm_launch_file = "";

                    string temp_value = "";

                    //Parse the XML manifest file, extracting data as needed
                    XmlTextReader reader = new XmlTextReader(ims_manifest_path);
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element: // The node is an element.
                                //Response.Write("&lt;" + reader.Name + "&gt;");
                                temp_value = reader.Name;
                                if (temp_value == "resource" && reader.HasAttributes)
                                {
                                    while (reader.MoveToNextAttribute())
                                    {
                                        if (reader.Name == "href" && scorm_launch_file == "")
                                            scorm_launch_file = HttpUtility.UrlEncode(reader.Value);
                                    }
                                }
                                break;
                            case XmlNodeType.Text: //Display the text in each element.
                                //Response.Write(reader.Value + "&lt;br /&gt;");
                                if (temp_value == "schemaversion" && scorm_schemaversion == "")
                                    scorm_schemaversion = reader.Value;
                                else if (temp_value == "title" && scorm_coursetitle == "")
                                    scorm_coursetitle = reader.Value;
                                break;
                            case XmlNodeType.EndElement: //Display the end of the element.
                                //Response.Write("&lt;/" + reader.Name + "&gt;");
                                break;
                        }
                    }
                    reader.Close();
                    reader = null;

                    SessionWrapper.c_course_title = scorm_coursetitle;
                    SessionWrapper.scorm_url = "/LMS/Courses/" + course_id + "/" + scorm_launch_file;

                    //txtDeliveryTitle.Text = SessionWrapper.c_course_title;
                    //txtScormUrl.Text = SessionWrapper.scorm_url;

                    if (scorm_schemaversion != "1.2")
                    {
                        //abort process and delete uploaded ZIP and unpacked files; do not save anything or post course information
                        scorm_package.Dispose();
                        File.Delete(zip_full_path);
                        Utility.DeleteDirectory(course_unpack_path);
                        //txtDeliveryTitle.Text = "";
                        SessionWrapper.scorm_url = "";
                        //txtScormUrl.Text = "";
                        SessionWrapper.c_course_system_id_pk = string.Empty;
                        SessionWrapper.c_course_title = string.Empty;
                        //StatusLabel.Text 
                        status = "This package is not SCORM 1.2 conformant and cannot be processed. Import canceled.";
                    }
                    else
                    { //Delete uploaded ZIP package after successful import
                        scorm_package.Dispose();
                        File.Delete(zip_full_path);
                    }
                }
                else
                    status = "Upload status: Course package must be a ZIP file.";
            }
            catch (Exception ex)
            {
                string error_text = "Upload status: The course package could not be imported. Error: " + ex.Message;
                status = error_text;
                Logger.WriteToErrorLog("Common/Scorm.cs", error_text);
            }

            return status;
        }
    }


}