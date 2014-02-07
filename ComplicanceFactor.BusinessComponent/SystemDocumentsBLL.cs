using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using System.Collections;
using System.Data;
using ComplicanceFactor.DataAccessLayer;

namespace ComplicanceFactor.BusinessComponent
{
    public class SystemDocumentsBLL
    {
        public static DataTable GetStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetStatus = new Hashtable();
                htGetStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_status", htGetStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDocumentTypes(string s_locale)
        {
            try
            {
                Hashtable htGetDocumentType = new Hashtable();
                htGetDocumentType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_document_types", htGetDocumentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateDocumentLocaleAttachment(string s_document_locale_system_id_pk, string s_document_locale_file_path, string s_document_locale_file_name)
        {
            Hashtable htLocale = new Hashtable();
            htLocale.Add("@s_document_locale_system_id_pk", s_document_locale_system_id_pk);
            htLocale.Add("@s_document_locale_file_path", s_document_locale_file_path);
            htLocale.Add("@s_document_locale_file_name", s_document_locale_file_name);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_document_locale_attachment", htLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertDocumentLocale(SystemDocuments resLocale)
        {
            Hashtable htInsertDocumentLocale = new Hashtable();
            htInsertDocumentLocale.Add("@s_document_id_fk", resLocale.s_document_system_id_pk);
            htInsertDocumentLocale.Add("@s_document_locale_name", resLocale.s_document_locale_name);
            htInsertDocumentLocale.Add("@s_document_locale_description", resLocale.s_document_locale_description);
            htInsertDocumentLocale.Add("@s_document_locale_id_fk", resLocale.s_document_locale_id_fk);
            if (!string.IsNullOrEmpty(resLocale.s_document_locale_file_path))
            {
                htInsertDocumentLocale.Add("@s_document_locale_file_path", resLocale.s_document_locale_file_path);
            }
            else
            {
                htInsertDocumentLocale.Add("@s_document_locale_file_path", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_document_locale_file_name))
            {
                htInsertDocumentLocale.Add("@s_document_locale_file_name", resLocale.s_document_locale_file_name);
            }
            else
            {
                htInsertDocumentLocale.Add("@s_document_locale_file_name", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_document_locale", htInsertDocumentLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDocumentLocale(string s_document_locale_system_id_pk)
        {
            Hashtable htGetLocale = new Hashtable();
            htGetLocale.Add("@s_document_locale_system_id_pk", s_document_locale_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_get_document_locale", htGetLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeleteDocumentLocale(string s_document_system_id_pk, string s_document_locale, string s_document_locale_system_id_pk)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_document_system_id_pk))
            {
                htDeleteLocale.Add("@s_document_system_id_pk", s_document_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_document_system_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_document_locale))
            {
                htDeleteLocale.Add("@s_document_locale", s_document_locale);
            }
            else
            {
                htDeleteLocale.Add("@s_document_locale", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_document_locale_system_id_pk))
            {
                htDeleteLocale.Add("@s_document_locale_system_id_pk", s_document_locale_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_document_locale_system_id_pk", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_document_locale", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ResetCategory(string s_document_system_id_pk, string s_document_category)
        {
            Hashtable htDeleteLocale = new Hashtable();
            if (!string.IsNullOrEmpty(s_document_system_id_pk))
            {
                htDeleteLocale.Add("@s_document_system_id_pk", s_document_system_id_pk);
            }
            else
            {
                htDeleteLocale.Add("@s_document_system_id_pk", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s_document_category))
            {
                htDeleteLocale.Add("@s_document_category", s_document_category);
            }
            else
            {
                htDeleteLocale.Add("@s_document_category", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_reset_document_category", htDeleteLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemDocuments GetSingleDocumentLocale(string s_locale_system_id_pk)
        {
            SystemDocuments resLocale;
            try
            {
                resLocale = new SystemDocuments();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_document_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = DataProxy.FetchDataTable("s_sp_get_single_document_locale", htGetLocale);
                resLocale.s_document_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                resLocale.s_document_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                resLocale.s_document_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                resLocale.s_document_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                resLocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                resLocale.s_document_locale_file_path = dtGetLocale.Rows[0]["s_locale_file_guid"].ToString();
                resLocale.s_document_locale_file_name = dtGetLocale.Rows[0]["s_locale_file_name"].ToString();
                return resLocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static SystemDocuments TempGetOneLocale(string s_locale_system_id_pk, DataTable dtTempLocale)
        {
            SystemDocuments reslocale;
            try
            {
                reslocale = new SystemDocuments();
                Hashtable htGetLocale = new Hashtable();
                htGetLocale.Add("@s_document_locale_system_id_pk", s_locale_system_id_pk);
                DataTable dtGetLocale = dtTempLocale;
                reslocale.s_document_locale_system_id_pk = dtGetLocale.Rows[0]["s_locale_system_id_pk"].ToString();
                reslocale.s_document_locale_id_fk = dtGetLocale.Rows[0]["s_locale_id_fk"].ToString();
                reslocale.s_document_locale_name = dtGetLocale.Rows[0]["s_locale_name"].ToString();
                reslocale.s_document_locale_description = dtGetLocale.Rows[0]["s_locale_description"].ToString();
                reslocale.s_locale_text = dtGetLocale.Rows[0]["s_locale_text"].ToString();
                reslocale.s_document_locale_file_path = dtGetLocale.Rows[0]["s_locale_file_guid"].ToString();
                reslocale.s_document_locale_file_name = dtGetLocale.Rows[0]["s_locale_file_name"].ToString();
                return reslocale;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int UpdateDocumentLocale(SystemDocuments resLocale)
        {
            Hashtable htUpdateDocumentLocale = new Hashtable();
            htUpdateDocumentLocale.Add("@s_document_locale_system_id_pk", resLocale.s_document_locale_system_id_pk);
            if (!string.IsNullOrEmpty(resLocale.s_document_locale_name))
            {
                htUpdateDocumentLocale.Add("@s_document_locale_name", resLocale.s_document_locale_name);
            }
            else
            {
                htUpdateDocumentLocale.Add("@s_document_locale_name", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_document_locale_description))
            {
                htUpdateDocumentLocale.Add("@s_document_locale_description", resLocale.s_document_locale_description);
            }
            else
            {
                htUpdateDocumentLocale.Add("@s_material_locale_description", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_document_locale_file_path))
            {
                htUpdateDocumentLocale.Add("@s_document_locale_file_path", resLocale.s_document_locale_file_path);
            }
            else
            {
                htUpdateDocumentLocale.Add("@s_document_locale_file_path", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(resLocale.s_document_locale_file_name))
            {
                htUpdateDocumentLocale.Add("@s_document_locale_file_name", resLocale.s_document_locale_file_name);
            }
            else
            {
                htUpdateDocumentLocale.Add("@s_document_locale_file_name", DBNull.Value);
            }
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_document_locale", htUpdateDocumentLocale);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int CreateNewDocument(SystemDocuments createDocument)
        {
            Hashtable htCreateDocument = new Hashtable();
            htCreateDocument.Add("@s_document_system_id_pk", createDocument.s_document_system_id_pk);
            htCreateDocument.Add("@s_document_id_pk", createDocument.s_document_id_pk);
            htCreateDocument.Add("@s_document_name", createDocument.s_document_name);
            htCreateDocument.Add("@s_document_description", createDocument.s_document_description);
            htCreateDocument.Add("@s_document_version", createDocument.s_document_version);
            htCreateDocument.Add("@s_document_status_id_fk", createDocument.s_document_status_id_fk);
            htCreateDocument.Add("@s_document_type_fk", createDocument.s_document_type_fk);
            htCreateDocument.Add("@s_documnet_attachment_file_guid", createDocument.s_documnet_attachment_file_guid);
            htCreateDocument.Add("@s_document_attachment_file_name", createDocument.s_document_attachment_file_name);


            if (!string.IsNullOrEmpty(createDocument.s_document_locale))
            {
                htCreateDocument.Add("@s_document_locale", createDocument.s_document_locale);
            }
            else
            {
                htCreateDocument.Add("@s_document_locale", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(createDocument.s_document_category))
            {
                htCreateDocument.Add("@s_document_category", createDocument.s_document_category);
            }
            else
            {
                htCreateDocument.Add("@s_document_category", DBNull.Value);
            }

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_document", htCreateDocument);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetDocument(string s_document_system_id_pk)
        {
            try
            {
                Hashtable htGetDocument = new Hashtable();
                htGetDocument.Add("@s_document_system_id_pk", s_document_system_id_pk);
                return DataProxy.FetchDataSet("s_sp_get_single_document", htGetDocument);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static SystemDocuments GetSingleDocument(string s_document_system_id_pk, DataTable dtDocument)
        {
            SystemDocuments getDocument = new SystemDocuments();
            try
            {
                Hashtable htGetDocument = new Hashtable();
                htGetDocument.Add("@s_document_system_id_pk", s_document_system_id_pk);
                DataTable dtSingleDocument = dtDocument;
                getDocument.s_document_id_pk = dtSingleDocument.Rows[0]["s_document_id_pk"].ToString();
                getDocument.s_document_name = dtSingleDocument.Rows[0]["s_document_name"].ToString();
                getDocument.s_document_description = dtSingleDocument.Rows[0]["s_document_description"].ToString();
                getDocument.s_document_version = dtSingleDocument.Rows[0]["s_document_version"].ToString();
                getDocument.s_document_status_id_fk = dtSingleDocument.Rows[0]["s_document_status_id_fk"].ToString();
                getDocument.s_document_type_fk = dtSingleDocument.Rows[0]["s_document_type_fk"].ToString();
                getDocument.s_documnet_attachment_file_guid = dtSingleDocument.Rows[0]["s_documnet_attachment_file_guid"].ToString();
                getDocument.s_document_attachment_file_name = dtSingleDocument.Rows[0]["s_document_attachment_file_name"].ToString();


                return getDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateDocument(SystemDocuments updateDocument)
        {
            Hashtable htUpdateDocument = new Hashtable();
            htUpdateDocument.Add("@s_document_system_id_pk", updateDocument.s_document_system_id_pk);
            htUpdateDocument.Add("@s_document_id_pk", updateDocument.s_document_id_pk);
            htUpdateDocument.Add("@s_document_name", updateDocument.s_document_name);
            htUpdateDocument.Add("@s_document_description", updateDocument.s_document_description);
            htUpdateDocument.Add("@s_document_status_id_fk", updateDocument.s_document_status_id_fk);
            htUpdateDocument.Add("@s_document_type_fk", updateDocument.s_document_type_fk);
            htUpdateDocument.Add("@s_documnet_attachment_file_guid", updateDocument.s_documnet_attachment_file_guid);
            htUpdateDocument.Add("@s_document_attachment_file_name", updateDocument.s_document_attachment_file_name);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_document", htUpdateDocument);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchDocuments(SystemDocuments document)
        {
            Hashtable htSearchDocument = new Hashtable();
            htSearchDocument.Add("@s_document_id_pk", document.s_document_id_pk);
            htSearchDocument.Add("@s_document_name", document.s_document_name);
            htSearchDocument.Add("@s_document_version", document.s_document_version);
            if (document.s_document_type_fk == "0")
                htSearchDocument.Add("@s_document_type_fk", DBNull.Value);
            else
                htSearchDocument.Add("@s_document_type_fk", document.s_document_type_fk);

            if (document.s_document_status_id_fk == "0")
                htSearchDocument.Add("@s_document_status_id_fk", DBNull.Value);
            else
                htSearchDocument.Add("@s_document_status_id_fk", document.s_document_status_id_fk);


            try
            {
                return DataProxy.FetchDataTable("s_sp_search_document", htSearchDocument);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateDocumentStatus(string s_document_system_id_pk)
        {
            Hashtable htUpdateDocumentStatus = new Hashtable();
            htUpdateDocumentStatus.Add("@s_document_system_id_pk", s_document_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_update_document_status", htUpdateDocumentStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllStatus(string s_ui_locale_name, string s_ui_page_name)
        {
            try
            {
                Hashtable htGetAllStatus = new Hashtable();
                htGetAllStatus.Add("@s_ui_locale_name", s_ui_locale_name);
                htGetAllStatus.Add("@s_ui_page_name", s_ui_page_name);
                return DataProxy.FetchDataTable("s_sp_get_all_status", htGetAllStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDocumentType(string s_locale)
        {
            try
            {
                Hashtable htGetDocumentType = new Hashtable();
                htGetDocumentType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_document_types", htGetDocumentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDocumentTypeNamedocument(string s_document_type_id, string s_locale)
        {
            try
            {
                Hashtable htGetDocumentType = new Hashtable();
                htGetDocumentType.Add("@s_document_type_id", s_document_type_id);
                htGetDocumentType.Add("@s_locale", s_locale);
                return DataProxy.FetchDataTable("s_sp_get_document_type_name", htGetDocumentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int CreateCourseNewVersion(SystemDocuments document)
        {
            Hashtable htNewVersion = new Hashtable();
            htNewVersion.Add("@s_document_system_id_pk", document.s_document_system_id_pk);
            htNewVersion.Add("@s_new_document_system_id_pk", document.s_new_document_system_id_pk);
            htNewVersion.Add("@s_document_version", document.s_document_version);
            htNewVersion.Add("@s_copy_document", document.s_copy_document);
            htNewVersion.Add("@s_copy_locale", document.s_copy_locale);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_document_new_version", htNewVersion);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDocumentsVersionList(string s_document_system_id_pk)
        {
            Hashtable htGetVersionList = new Hashtable();
            //htGetVersionList.Add("@u_time_zone_id_pk", u_time_zone_id_pk);
            htGetVersionList.Add("@s_document_system_id_pk", s_document_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_documents_sp_get_version_list", htGetVersionList);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get CourseCategory
        /// </summary>
        /// <param name="c_course_system_id_pk"></param>
        /// <returns></returns>
        public static DataTable GetDocumentCategory(string s_document_system_id_pk)
        {
            Hashtable htGetCourseCategory = new Hashtable();
            htGetCourseCategory.Add("@s_document_system_id_pk", s_document_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_document_sp_get_categories", htGetCourseCategory);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDocumentCategory_Copy(string s_document_system_id_pk)
        {
            Hashtable htGetCourseCategory = new Hashtable();
            htGetCourseCategory.Add("@c_document_id_fk", s_document_system_id_pk);
            try
            {
                return DataProxy.FetchDataTable("s_sp_document_category_for_copy", htGetCourseCategory);
            }

            catch (Exception)
            {
                throw;
            }
        }

        

        /// <summary>
        /// Delete Category
        /// </summary>
        public static int DeleteCategory(string c_document_system_id_pk)
        {
            Hashtable htDeleteCategory = new Hashtable();
            htDeleteCategory.Add("@c_document_system_id_pk", c_document_system_id_pk);
            try
            {
                return DataProxy.FetchSPOutput("s_sp_delete_document_category", htDeleteCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insert Category
        /// </summary>
        public static int InsertCategory(string s_document_category, string c_document_id_fk)
        {
            Hashtable htInsertCategory = new Hashtable();

            htInsertCategory.Add("@s_document_category", s_document_category);
            htInsertCategory.Add("@c_document_id_fk", c_document_id_fk);

            try
            {
                return DataProxy.FetchSPOutput("s_sp_insert_document_categories", htInsertCategory);
            }
            catch
            {
                throw;
            }
        }

    }
}
