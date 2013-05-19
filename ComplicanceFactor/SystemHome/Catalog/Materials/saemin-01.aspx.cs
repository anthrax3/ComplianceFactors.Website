using System;
using System.Web;
using System.Web.UI.WebControls;
using ComplicanceFactor.BusinessComponent;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.Common;
using System.Data;
using System.IO;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.SystemHome.Catalog.Materials
{
    public partial class saemin_01 : BasePage
    {
        private string _filePath = "~/SystemHome/Catalog/Materials/Upload/";
        string editMaterial;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    editMaterial = SecurityCenter.DecryptText(Request.QueryString["edit"]);
                }
                //set material id
                hdMaterialId.Value = editMaterial;
                if (!IsPostBack)
                {
                    //clear attachment session
                    SessionWrapper.Attachment_file_name = string.Empty;
                    SessionWrapper.Attachment_guid = string.Empty;
                    // bind the status
                    ddlStatus.DataSource = SystemMaterialBLL.GetStatus(SessionWrapper.CultureName,"saemin-01");
                    ddlStatus.DataBind();

                    //bind material type
                    ddlMaterialType.DataSource = SystemMaterialBLL.GetMaterialType(SessionWrapper.CultureName);
                    ddlMaterialType.DataBind();
                    ListItem itemToRemove = ddlMaterialType.Items.FindByValue("app_ddl_all_text");
                    ddlMaterialType.Items.Remove(itemToRemove);
                    PopulateMaterial();

                    //LabelCrumb
                    //Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    //lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Materials/sammimp-01.aspx>" + LocalResources.GetLabel("app_manage_material_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_material_text");

                    string navigationText;
                    Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                    navigationText = BreadCrumb.GetCurrentBreadCrumb(SessionWrapper.navigationText);
                    hdNav_selected.Value = "#" + SessionWrapper.navigationText;
                    lblBreadCrumb.Text = navigationText + "&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Catalog/Materials/sammimp-01.aspx>" + LocalResources.GetLabel("app_manage_material_text") + "</a>&nbsp;" + " >&nbsp;" + LocalResources.GetLabel("app_edit_material_text");


                    Attachment();
                    //Success Message
                    if (!string.IsNullOrEmpty(Request.QueryString["succ"]))
                    {
                        divSuccess.Style.Add("display", "block");
                        divError.Style.Add("display", "none");
                        divSuccess.InnerText = LocalResources.GetText("app_succ_insert_text");
                    }
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
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message);
                    }
                }
            }
        }
        //Attachment datatable
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

        private void PopulateMaterial()
        {
            SystemMaterial material = new SystemMaterial();
            DataSet dsMaterial = SystemMaterialBLL.GetMaterial(editMaterial);
            try
            {
                material = SystemMaterialBLL.GetSingleMaterial(editMaterial,dsMaterial.Tables[0]);
                txtMaterialId.Text = material.c_material_id_pk;
                txtMaterialName.Text = material.c_material_name;
                txtMaterialDescription.InnerText = material.c_material_description;
                ddlStatus.SelectedValue = material.c_material_status_id;
                ddlMaterialType.SelectedValue = material.c_material_type_id_fk;
                SessionWrapper.Attachment_guid = material.c_material_file_guid;
                SessionWrapper.Attachment_file_name = material.c_material_file_name;
                //for reset to store resource locale in session
                SessionWrapper.TempLocale = TempDataTables.TempLocale();
                SessionWrapper.TempLocale = dsMaterial.Tables[1];
            }
            catch (Exception ex)
            {
                //TODO: Show user friendly error here
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message);
                    }
                }
            }
        }
       /// <summary>
       /// reset
       /// </summary>
        private void Reset()
        {
            try
            {
                SystemMaterialBLL.DeleteMaterialLocale(editMaterial, ConvertDataTableToXml(SessionWrapper.TempLocale),string.Empty);
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message);
                    }
                }
            }
        }

        ///<summary>
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

        protected void btnHeaderSaveNewMaterial_Click(object sender, EventArgs e)
        {
            UpdateMaterial();
        }

        protected void btnFooterSaveNewMaterials_Click(object sender, EventArgs e)
        {
            UpdateMaterial();
        }

        private void UpdateMaterial()
        {
            SystemMaterial updateMaterial = new SystemMaterial();

            updateMaterial.c_material_system_id_pk = editMaterial;
            updateMaterial.c_material_id_pk = txtMaterialId.Text;
            updateMaterial.c_material_name = txtMaterialName.Text;
            updateMaterial.c_material_description = txtMaterialDescription.InnerText;
            updateMaterial.c_material_status_id = ddlStatus.SelectedValue;
            updateMaterial.c_material_type_id_fk = ddlMaterialType.SelectedValue;
            updateMaterial.c_material_file_guid = SessionWrapper.Attachment_guid;
            updateMaterial.c_material_file_name = SessionWrapper.Attachment_file_name;
            try
            {
                int result = SystemMaterialBLL.UpdateMaterial(updateMaterial);
                if (result == 0)
                {
                    if (result == 0)
                    {
                        divSuccess.Style.Add("display", "block");
                        divSuccess.InnerHtml = LocalResources.GetText("app_succ_update_text");
                    }
                }
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("saemin-01.aspx", ex.Message);
                    }
                }
            }
        }

        protected void btnHeaderReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterReset_Click(object sender, EventArgs e)
        {
            Reset();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFooterCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Materials/sammimp-01.aspx");
        }

        protected void btnHeaderCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Catalog/Materials/sammimp-01.aspx");
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            AttachmentDownload();
        }
        private void AttachmentDownload()
        {

            string filePath = Server.MapPath(_filePath + SessionWrapper.Attachment_guid);

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
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SessionWrapper.Attachment_file_name = string.Empty;
            SessionWrapper.Attachment_guid = string.Empty;
            lnkFileName.Text = string.Empty;
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
    }
}