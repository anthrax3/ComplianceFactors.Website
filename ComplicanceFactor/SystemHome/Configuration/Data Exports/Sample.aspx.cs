using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Text;
using System.IO;
using System.Net;

namespace ComplicanceFactor.SystemHome.Configuration.Data_Exports
{
    public partial class Sample : System.Web.UI.Page
    {
        public static string APP_PATH = HttpContext.Current.Server.MapPath("~/SystemHome/Configuration/Data Exports/Download/");

        public static string FACILITIES_FILE_PATH = APP_PATH + "Facilities.csv";
        public static string HRIS_FILE_PATH = APP_PATH + "Hris.csv";
        public static string ROOMS_FILE_PATH = APP_PATH + "Rooms.csv";
        public static string COURSES_FILE_PATH = APP_PATH + "Courses.csv";
        public static string CURRICULUM_FILE_PATH = APP_PATH + "Curriculum.csv";
        public static string ENROLLMENTS_FILE_PATH = APP_PATH + "Enrollment.csv";
        public static string LEARNING_HISTORY_FILE_PATH = APP_PATH + "Learning_History.csv";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportToCSV(object sender, EventArgs e)
        {
            DataTable dtFacilities = new DataTable();
            dtFacilities = SystemDataImportExportBLL.GetFacilities();
            GetDatatableToCsv(dtFacilities, FACILITIES_FILE_PATH);

            DataTable dtCourses = new DataTable();
            dtCourses = SystemDataImportExportBLL.GetCourses();
            GetDatatableToCsv(dtCourses, COURSES_FILE_PATH);

            DataTable dtCurriculum = new DataTable();
            dtCurriculum = SystemDataImportExportBLL.GetCurriculum();
            GetDatatableToCsv(dtCurriculum, CURRICULUM_FILE_PATH);

            DataTable dtEnrollments = new DataTable();
            dtEnrollments = SystemDataImportExportBLL.GetEnrollments();
            GetDatatableToCsv(dtEnrollments, ENROLLMENTS_FILE_PATH);

            DataTable dtLearningHistory = new DataTable();
            dtLearningHistory = SystemDataImportExportBLL.GetLearningHisory();
            GetDatatableToCsv(dtLearningHistory, LEARNING_HISTORY_FILE_PATH);

            DataTable dtRooms = new DataTable();
            dtRooms = SystemDataImportExportBLL.GetRooms();
            GetDatatableToCsv(dtRooms, ROOMS_FILE_PATH);

            DataTable dtHris = new DataTable();
            dtHris = SystemDataImportExportBLL.GetHris();
            GetDatatableToCsv(dtHris, HRIS_FILE_PATH);

        }

        private void GetDatatableToCsv(DataTable dt,String path)
        {
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                //add separator
                sb.Append(dt.Columns[k].ColumnName + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
                }
                //append new line
                sb.Append("\r\n");
            }

            FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                System.IO.File.Delete(path);
            }
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;
        }

        protected void btUpload_Click(object sender, EventArgs e)
        {
            FileInfo toUpload = new FileInfo("Facilities.csv");
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://compfact@174.121.42.195/compliancefactors.com/wwwroot/ComplianceSystem/SystemHome/Configuration/HRISIntegration/Log/" + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("compfact", "Factors1");
            Stream ftpStream = request.GetRequestStream();

            FileStream file = File.OpenRead(APP_PATH+"Facilities.csv");

            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;

            do
            {
                bytesRead = file.Read(buffer, 0, length);
                ftpStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();
        }

        protected void Read_Click(object sender, EventArgs e)
        {
            string CSVFilePathName = APP_PATH + "Facilities.csv";
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols-1; i++)
                dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            DataRow Row;
            for (int i = 0; i < Lines.GetLength(0)-1; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols-1; f++)
                    Row[f] = Fields[f];
                dt.Rows.Add(Row);
            }
        }


    }
}