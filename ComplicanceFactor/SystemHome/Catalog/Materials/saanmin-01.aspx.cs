using System;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using ComplicanceFactor.Common;
using System.Data;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Materials
{
    public partial class saanmin_01 : BasePage
    {
        private string _filePath = "~/SystemHome/Catalog/Materials/Upload/";

        private DataTable dtTempAttachment = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //clear attachment session
                    SessionWrapper.Attachment_file_name = string.Empty;
                    SessionWrapper.Attachment_guid = string.Empty;
                    //to bind the Attachment
                    dtTempAttachment = new DataTable();
                    dtTempAttachment = tempAttachment();
                    SessionWrapper.session_Attachment = dtTempAttachment;
                    //temp locale column
                    SessionWrapper.Locale = TempDataTables.TempLocale();
                    SessionWrapper.TempLocale = TempDataTables.TempLocale();
                    // bind the status
                    ddlStatus.DataSource = SystemMaterialBLL.GetStatus(SessionWrapper.CultureName,"saanmin-01");
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = "app_ddl_active_text";
                    //bind material type
                    ddlMaterialType.DataSource = SystemMaterialBLL.GetMaterialType(SessionWrapper.CultureName);
                    ddlMaterialType.DataBind();
                    ListItem itemToRemove = ddlMaterialType.Items.FindByValue("app_ddl_all_text");
                    ddlMaterialType.Items.Remove(itemToRemove);
                    //copy
                    if (!string.IsNullOrEmpty(Request.QueryString["Copy"]))
                    {
                        PopulateMaterial(SecurityCenter.DecryptText(Request.QueryString["Copy"]));
                    }
                    Attachment();
                    //label BreadCrumb
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetLocalizationResourceLabelText("app_system_text") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Materials/sammimp-01.aspx>" + LocalResources.GetLocalizationResourceLabelText("app_manage_material_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLocalizationResourceLabelText("app_create_new_material_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Materials/sammimp-01.aspx>" + LocalResources.GetGlobalLabel("app_manage_material_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_create_new_material_text") + "</a>";


                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanmin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanmin-01.aspx", ex.Message);
                    }
                }
            }

        }

        protected void btnUploadAttachment_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string m_file_name = null;
                string m_file_extension = null;
                string m_file_guid = Guid.NewGuid().ToString();
                if (file != null && file.ContentLength > 0)
                {
                    m_file_name = Path.GetFileName(file.FileName);
                    m_file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_filePath + m_file_guid + m_file_extension));

                    SessionWrapper.Attachment_file_name = m_file_name;
                    SessionWrapper.Attachment_guid = m_file_guid + m_file_extension;

                }
            }
            Attachment();



        }
        /// <summary>
        /// Attachment
        /// </summary>
        private void Attachment()
        {
            if (!string.IsNullOrEmpty(SessionWrapper.Attachment_file_name))
            {
                lnkFileName.Text = SessionWrapper.Attachment_file_name;
                btnAttachment.Style.Add("display", "none");
                btnEdit.Style.Add("display", "inline");
                btnRemove.Style.Add("display", "inline");
                btnView.Style.Add("display", "inline");
            }
            else
            {
                lnkFileName.Text = string.Empty;
                btnAttachment.Style.Add("display", "inline");
                btnEdit.Style.Add("display", "none");
                btnRemove.Style.Add("display", "none");
                btnView.Style.Add("display", "none");

            }
        }
        //Attachment 
        private DataTable tempAttachment()
        {
            DataTable dtTempAttachment = new DataTable();
            DataColumn dtTempAttachmentColumn;

            dtTempAttachmentColumn = new DataColumn();
            dtTempAttachmentColumn.DataType = Type.GetType("System.String");
            dtTempAttachmentColumn.ColumnName = "c_material_file_guid";
            dtTempAttachment.Columns.Add(dtTempAttachmentColumn);

            dtTempAttachmentColumn = new DataColumn();
            dtTempAttachmentColumn.DataType = Type.GetType("System.String");
            dtTempAttachmentColumn.ColumnName = "c_material_file_name";
            dtTempAttachment.Columns.Add(dtTempAttachmentColumn);
            return dtTempAttachment;
        }
        // Add Attachment to the session       
        private void AddDataToTempAttachment(string h_file_guid, string h_file_name, DataTable dtTempAttachment)
        {
            DataRow row;
            row = dtTempAttachment.NewRow();
            row["c_material_file_guid"] = h_file_guid;
            row["c_material_file_name"] = h_file_name;
            dtTempAttachment.Rows.Add(row);
        }
        // Edit the session (or) datatable values        
        private void EditDataToTempAttachment(int rowIndex, string h_file_guid, string h_file_name, DataTable dtTempAttachment)
        {
            dtTempAttachment.Rows[rowIndex]["c_material_file_guid"] = h_file_guid;
            dtTempAttachment.Rows[rowIndex]["c_material_file_name"] = h_file_name;
            dtTempAttachment.AcceptChanges();
        }
        // Delete the Data from grid        

        private void DeleteDataToTempAttachment(int rowIndex, DataTable dtTempAttachment)
        {
            dtTempAttachment.Rows[rowIndex].Delete();
            dtTempAttachment.AcceptChanges();
            // this.gvAttachment.DataSource = (SessionWrapper.session_Custom_Customer).DefaultView;
            // this.gvAttachment.DataBind();
            btnAttachment.Enabled = true;
        }
        protected void btnFooterSaveNewMaterials_Click(object sender, EventArgs e)
        {
            SaveMaterial();
        }
        protected void btnHeaderSaveNewMaterial_Click(object sender, EventArgs e)
        {
            SaveMaterial();
        }

        /// <summary>
        /// Save Material
        /// </summary>

        private void SaveMaterial()
        {
            SystemMaterial createMaterial = new SystemMaterial();

            createMaterial.c_material_system_id_pk = Guid.NewGuid().ToString();
            createMaterial.c_material_id_pk = txtMaterialId.Text;
            createMaterial.c_material_name = txtMaterialName.Text;
            createMaterial.c_material_description = txtMaterialDescription.InnerText;
            createMaterial.c_material_status_id = ddlStatus.SelectedValue;
            createMaterial.c_material_type_id_fk = ddlMaterialType.SelectedValue;
            createMaterial.c_material_file_guid = SessionWrapper.Attachment_guid;
            createMaterial.c_material_file_name = SessionWrapper.Attachment_file_name;
            createMaterial.s_material_locale = ConvertDataTableToXml(SessionWrapper.Locale);
            try
            {
                int result = SystemMaterialBLL.CreateNewMaterial(createMaterial);
                if (result == 0)
                {
                    Response.Redirect("~/SystemHome/Catalog/Materials/saemin-01.aspx?edit=" + SecurityCenter.EncryptText(createMaterial.c_material_system_id_pk) + "&succ=" + SecurityCenter.EncryptText("true"), false);
                }
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanmin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanmin-01.aspx", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Populate Material
        /// </summary>
        /// <param name="materialId"></param>
        private void PopulateMaterial(string materialId)
        {
            SystemMaterial material = new SystemMaterial();
            DataSet dsMaterial = SystemMaterialBLL.GetMaterial(materialId);
            try
            {
                material = SystemMaterialBLL.GetSingleMaterial(materialId,dsMaterial.Tables[0]);
                txtMaterialId.Text = material.c_material_id_pk + "_copy";
                txtMaterialName.Text = material.c_material_name;
                txtMaterialDescription.InnerText = material.c_material_description;
                ddlStatus.SelectedValue = material.c_material_status_id;
                ddlMaterialType.SelectedValue = material.c_material_type_id_fk;
                SessionWrapper.Attachment_guid = material.c_material_file_guid;
                SessionWrapper.Attachment_file_name = material.c_material_file_name;
                //AddDataToTempAttachment(material.c_material_file_guid, material.c_material_file_name, SessionWrapper.session_Attachment);
                // gvAttachment.DataSource = dtTempAttachment;
                // gvAttachment.DataBind();
                SessionWrapper.Locale = dsMaterial.Tables[1];
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saanmin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saanmin-01.aspx", ex.Message);
                    }
                }
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

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Materials/sammimp-01.aspx");
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Materials/sammimp-01.aspx");
        }

       

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }
        private void AttachmentDownload()
        {
            
            string filePath = Server.MapPath( _filePath + SessionWrapper.Attachment_guid);

            if (System.IO.File.Exists(filePath))
            {
                string strRequest = filePath;
                if (!string.IsNullOrEmpty(strRequest))
                {
                    FileInfo file = new System.IO.FileInfo(strRequest);
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + SessionWrapper.Attachment_file_name + "\"");
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
        protected void btnView_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }

        /// This method is used to convert the DataTable into string XML format.
        ///
        /// DataTable to be converted./// (string) XML form of the DataTable.
        /// </summary>
        public string ConvertDataTableToXml(DataTable dtBuildSql)
        {
            DataSet dsBuildSql = new DataSet("DataSet");

            dsBuildSql.Tables.Add(dtBuildSql.Copy());
            dsBuildSql.Tables[0].TableName = "Table";

            foreach (DataColumn col in dsBuildSql.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            return dsBuildSql.GetXml().ToString();
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.Attachment_file_name = string.Empty;
            SessionWrapper.Attachment_guid = string.Empty;
            lnkFileName.Text = string.Empty;
            Attachment();

        }
    }
}