using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplicanceFactor.Common;
using ComplicanceFactor.BusinessComponent.DataAccessObject;
using ComplicanceFactor.BusinessComponent;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ComplicanceFactor.Common.Languages;
using System.Xml.Serialization;



namespace ComplicanceFactor.SystemHome.Configuration.Languages
{

    public partial class salpmp_01 : BasePage
    {
        #region "Private Member Variables"
        private string _path = "~/SystemHome/Configuration/Languages/Import/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblBreadCrumb = (Label)Master.FindControl("lblBreadCrumb");
                lblBreadCrumb.Text = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>&nbsp;" + " >&nbsp;" + "<a href=/SystemHome/Configuration/sascmp-01.aspx>" + LocalResources.GetLabel("app_manage_configuration_text") + "</a>&nbsp;" + " >&nbsp;" + "<a class=bread_text>" + LocalResources.GetLabel("app_manage_languages_text") + "</a>";

                Language();
            }


        }
        private void Language()
        {
            try
            {
                SystemLocale locale = new SystemLocale();
                locale = SystemLocaleBLL.GetAllLocale();
                txtus_english.Text = locale.s_locale_us_english;
                txtEnglishUK.Text = locale.s_locale_uk_english;
                txtFrenchCA.Text = locale.s_locale_ca_french;
                txtFrenchFR.Text = locale.s_locale_fr_french;
                txtSpanishMX.Text = locale.s_locale_mx_spanish;
                txtSpanishSpain.Text = locale.s_locale_sp_spanish;
                txtPortuguese.Text = locale.s_locale_portuguese;
                txtChinese.Text = locale.s_locale_simp_chinese;
                txtGerman.Text = locale.s_locale_german;
                txtJapanese.Text = locale.s_locale_japanese;
                txtRussian.Text = locale.s_locale_russian;
                txtDanish.Text = locale.s_locale_danish;
                txtPolish.Text = locale.s_locale_polish;
                txtSwedish.Text = locale.s_locale_swedish;
                txtFinnish.Text = locale.s_locale_finnish;
                txtKorean.Text = locale.s_locale_korean;
                txtItalian.Text = locale.s_locale_italian;
                txtDutch.Text = locale.s_locale_dutch;
                txtIndonesian.Text = locale.s_locale_indonesian;
                txtGreek.Text = locale.s_locale_greek;
                txtHungarian.Text = locale.s_locale_hungarian;
                txtNorwegian.Text = locale.s_locale_norwegian;
                txtTurkish.Text = locale.s_locale_turkish;
                txtArabic.Text = locale.s_locale_arabic_rtl;
                txtCustom01.Text = locale.s_locale_custom_01;
                txtCustom02.Text = locale.s_locale_custom_02;
                txtCustom03.Text = locale.s_locale_custom_03;
                txtCustom04.Text = locale.s_locale_custom_04;
                txtCustom05.Text = locale.s_locale_custom_05;
                txtCustom06.Text = locale.s_locale_custom_06;
                txtCustom07.Text = locale.s_locale_custom_07;
                txtCustom08.Text = locale.s_locale_custom_08;
                txtCustom09.Text = locale.s_locale_custom_09;
                txtCustom10.Text = locale.s_locale_custom_10;
                txtCustom11.Text = locale.s_locale_custom_11;
                txtCustom12.Text = locale.s_locale_custom_12;
                txtCustom13.Text = locale.s_locale_custom_13;
                //visible
                chk_us_english.Checked = locale.s_locale_visible_us_english;
                chk_uk_english.Checked = locale.s_locale_visible_uk_english;
                chk_ca_french.Checked = locale.s_locale_visible_ca_french;
                chk_fr_french.Checked = locale.s_locale_visible_fr_french;
                chk_mx_spanish.Checked = locale.s_locale_visible_mx_spanish;
                chk_sp_spanish.Checked = locale.s_locale_visible_sp_spanish;
                chk_portuguese.Checked = locale.s_locale_visible_portuguese;
                chk_simp_chinese.Checked = locale.s_locale_visible_simp_chinese;
                chk_german.Checked = locale.s_locale_visible_german;
                chk_japanese.Checked = locale.s_locale_visible_japanese;
                chk_russian.Checked = locale.s_locale_visible_russian;
                chk_danish.Checked = locale.s_locale_visible_danish;
                chk_polish.Checked = locale.s_locale_visible_polish;
                chk_swedish.Checked = locale.s_locale_visible_swedish;
                chk_finnish.Checked = locale.s_locale_visible_finnish;
                chk_korean.Checked = locale.s_locale_visible_korean;
                chk_italian.Checked = locale.s_locale_visible_italian;
                chk_dutch.Checked = locale.s_locale_visible_dutch;
                chk_indonesian.Checked = locale.s_locale_visible_indonesian;
                chk_greek.Checked = locale.s_locale_visible_greek;
                chk_hungarian.Checked = locale.s_locale_visible_hungarian;
                chk_norwegian.Checked = locale.s_locale_visible_norwegian;
                chk_turkish.Checked = locale.s_locale_visible_turkish;
                chk_arabic_rtl.Checked = locale.s_locale_visible_arabic_rtl;
                chk_Custom01.Checked = locale.s_locale_visible_custom_01;
                chk_Custom02.Checked = locale.s_locale_visible_custom_02;
                chk_Custom03.Checked = locale.s_locale_visible_custom_03;
                chk_Custom04.Checked = locale.s_locale_visible_custom_04;
                chk_Custom05.Checked = locale.s_locale_visible_custom_05;
                chk_Custom06.Checked = locale.s_locale_visible_custom_06;
                chk_Custom07.Checked = locale.s_locale_visible_custom_07;
                chk_Custom08.Checked = locale.s_locale_visible_custom_08;
                chk_Custom09.Checked = locale.s_locale_visible_custom_09;
                chk_Custom10.Checked = locale.s_locale_visible_custom_10;
                chk_Custom11.Checked = locale.s_locale_visible_custom_11;
                chk_Custom12.Checked = locale.s_locale_visible_custom_12;
                chk_Custom13.Checked = locale.s_locale_visible_custom_13;
            }
            catch (Exception ex)
            {
                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("salpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("salpmp-01.aspx", ex.Message);
                    }
                }
            }


        }
        private void UpdateVisibility(string locale, bool visible, string localeText)
        {
            try
            {

                SystemLocaleBLL.UpdateLocaleVisibility(locale, visible, localeText);
                DropDownList ddlLanaguage = (DropDownList)Master.FindControl("ddlLanguages");
                ddlLanaguage.Items.Clear();
                ddlLanaguage.DataSource = SystemLocaleBLL.GetLocaleList();
                ddlLanaguage.DataBind();

            }
            catch (Exception ex)
            {

                //Log here
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("salpmp-01.aspx", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("salpmp-01.aspx", ex.Message);
                    }
                }
            }
        }
        protected void chk_us_english_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("us_english", chk_us_english.Checked, txtus_english.Text);
        }
        protected void chk_uk_english_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("uk_english", chk_uk_english.Checked, txtEnglishUK.Text);
        }
        protected void chk_ca_french_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("ca_french", chk_ca_french.Checked, txtFrenchCA.Text);
        }
        protected void chk_fr_french_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("fr_french", chk_fr_french.Checked, txtFrenchFR.Text);
        }
        protected void chk_mx_spanish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("mx_spanish", chk_mx_spanish.Checked, txtSpanishMX.Text);
        }
        protected void chk_sp_spanish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("sp_spanish", chk_sp_spanish.Checked, txtSpanishSpain.Text);
        }
        protected void chk_portuguese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("portuguese", chk_portuguese.Checked, txtPortuguese.Text);
        }
        protected void chk_simp_chinese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("simp_chinese", chk_simp_chinese.Checked, txtChinese.Text);
        }
        protected void chk_german_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("german", chk_german.Checked, txtGerman.Text);
        }
        protected void chk_japanese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("japanese", chk_japanese.Checked, txtJapanese.Text);
        }
        protected void chk_russian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("russian", chk_russian.Checked, txtRussian.Text);
        }
        protected void chk_danish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("danish", chk_danish.Checked, txtDanish.Text);
        }
        protected void chk_polish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("polish", chk_polish.Checked, txtPolish.Text);
        }
        protected void chk_swedish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("swedish", chk_swedish.Checked, txtSwedish.Text);
        }
        protected void chk_finnish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("finnish", chk_finnish.Checked, txtFinnish.Text);
        }
        protected void chk_korean_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("korean", chk_korean.Checked, txtKorean.Text);
        }
        protected void chk_italian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("italian", chk_italian.Checked, txtItalian.Text);
        }
        protected void chk_dutch_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("dutch", chk_dutch.Checked, txtDutch.Text);
        }
        protected void chk_indonesian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("indonesian", chk_indonesian.Checked, txtIndonesian.Text);
        }
        protected void chk_greek_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("greek", chk_greek.Checked, txtGreek.Text);
        }
        protected void chk_hungarian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("hungarian", chk_hungarian.Checked, txtHungarian.Text);
        }
        protected void chk_norwegian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("norwegian", chk_norwegian.Checked, txtNorwegian.Text);
        }
        protected void chk_turkish_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("turkish", chk_turkish.Checked, txtTurkish.Text);
        }
        protected void chk_arabic_rtl_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("arabic_rtl", chk_arabic_rtl.Checked, txtArabic.Text);
        }
        protected void chk_Custom01_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_01", chk_Custom01.Checked, txtCustom01.Text);
        }
        protected void chk_Custom02_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_02", chk_Custom02.Checked, txtCustom02.Text);
        }
        protected void chk_Custom03_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_03", chk_Custom03.Checked, txtCustom03.Text);
        }
        protected void chk_Custom04_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_04", chk_Custom04.Checked, txtCustom04.Text);
        }
        protected void chk_Custom05_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_05", chk_Custom05.Checked, txtCustom05.Text);
        }
        protected void chk_Custom06_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_06", chk_Custom06.Checked, txtCustom06.Text);
        }
        protected void chk_Custom07_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_07", chk_Custom07.Checked, txtCustom07.Text);
        }
        protected void chk_Custom08_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_08", chk_Custom08.Checked, txtCustom08.Text);
        }
        protected void chk_Custom09_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_09", chk_Custom09.Checked, txtCustom09.Text);
        }
        protected void chk_Custom10_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_10", chk_Custom10.Checked, txtCustom10.Text);
        }
        protected void chk_Custom11_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_11", chk_Custom11.Checked, txtCustom11.Text);
        }
        protected void chk_Custom12_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_12", chk_Custom12.Checked, txtCustom12.Text);
        }
        protected void chk_Custom13_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibility("custom_13", chk_Custom13.Checked, txtCustom13.Text);
        }
        protected void btnExportLanguage_Click(object sender, EventArgs e)
        {

            DataSet dsAllLabelTextDropdown = new DataSet();
            dsAllLabelTextDropdown = SystemLocaleBLL.GetAllLabelTextDropdown();
            dsAllLabelTextDropdown.Tables[0].TableName = "Labels";
            dsAllLabelTextDropdown.Tables[1].TableName = "Texts";
            dsAllLabelTextDropdown.Tables[2].TableName = "Dropdowns";
            exportDataTableToCsv(dsAllLabelTextDropdown, "Export.xlsx");
       
        }
        private void exportDataTableToCsv(DataSet ds, string filename)
        {
            MemoryStream ms = ExcelUtility.GetStreamFromDataSet(ds);
            Response.Clear();
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", filename));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.ContentEncoding = Encoding.Unicode;
            ms.WriteTo(Response.OutputStream);
            Response.End();


            //Response.ContentType = "application/csv";
            //Response.Charset = "";
            //Response.AddHeader("Content-Disposition", "attachment;filename=Export.csv");
            //Response.ContentEncoding = Encoding.Unicode;
            //StringBuilder sb = new StringBuilder();
            //for (int k = 0; k < dt.Columns.Count; k++)
            //{
            //    //add separator
            //    sb.Append(dt.Columns[k].ColumnName + ',');
            //}
            ////append new line
            //sb.Append("\r\n");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int k = 0; k < dt.Columns.Count; k++)
            //    {
            //        //add separator
            //        sb.Append(dt.Rows[i][k].ToString().Replace(",", ",") + ',');
            //    }

            //    //append new line
            //    sb.Append("\r\n");

            //}
            //Response.Output.Write(sb.ToString());
            //Response.Flush();
            //Response.End();


        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = default(HttpPostedFile);
            foreach (string files in Request.Files)
            {
                file = Request.Files[files];
                string file_name = null;
                string file_extension = null;
                DateTime file_date_time = DateTime.UtcNow;
                if (file != null && file.ContentLength > 0)
                {
                    file_name = Path.GetFileNameWithoutExtension(file.FileName);
                    file_name = Guid.NewGuid().ToString();
                    file_extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(_path + file_name + file_extension));
                    string path = Server.MapPath(_path + file_name + file_extension);
                    DataTable dtLabel = getExcelData(path, "Labels");
                    DataTable dtText = getExcelData(path, "Texts");
                    DataTable dtDropdown = getExcelData(path,"Dropdowns");

                    try
                    {
                        SystemLocaleBLL.Import_UI_Label_Text_Dropdown(ConvertDataTableToXml(dtLabel), ConvertDataTableToXml(dtText), ConvertDataTableToXml(dtDropdown));
                        File.Delete(Server.MapPath(_path + file_name + file_extension));
                    }
                    catch (Exception ex)
                    {
                        //Log here
                        if (ConfigurationWrapper.LogErrors == true)
                        {
                            if (ex.InnerException != null)
                            {
                                Logger.WriteToErrorLog("salpmp-01.aspx", ex.Message, ex.InnerException.Message);
                            }
                            else
                            {
                                Logger.WriteToErrorLog("salpmp-01.aspx", ex.Message);
                            }
                        }
                    }

                }

            }
        }
        /// <summary>
        /// convert datatable to xml
        /// </summary>
        /// <param name="dtBuildSql"></param>
        /// <returns>string</returns>
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
        /// <summary>
        /// convert excel to datatable
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strSheetName"></param>
        /// <returns>datatable</returns>
        public static DataTable getExcelData(string FileName, string strSheetName)
        {
            DataTable dt = new DataTable();

            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(FileName, false))
            {

                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;

                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == strSheetName);
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();

                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                foreach (Cell cell in rows.ElementAt(0))
                {
                    dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                }

                foreach (Row row in rows) //this will also include your header row...
                {
                    DataRow tempRow = dt.NewRow();

                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                    }

                    dt.Rows.Add(tempRow);
                }

            }
            dt.Rows.RemoveAt(0); //...so i'm taking it out here.

            return dt;

        }
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        protected void btnFooterClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/sascmp-01.aspx",false);
        }
        protected void btnHeaderClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SystemHome/Configuration/sascmp-01.aspx", false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemLocale locale = new SystemLocale();
            DataTable dtLanguage = new DataTable();
            dtLanguage.Columns.Add("Id");
            dtLanguage.Columns.Add("LanguageName");
            dtLanguage.Columns.Add("IsVisible");
            DataRow dr;

            dr = dtLanguage.NewRow();
            dr["Id"] = "us_english";
            dr["LanguageName"] = txtus_english.Text;
            dr["IsVisible"] = chk_us_english.Checked;
            dtLanguage.Rows.Add(dr);


            dr = dtLanguage.NewRow();
            dr["Id"] = "uk_english";
            dr["LanguageName"] = txtEnglishUK.Text;
            dr["IsVisible"] = chk_uk_english.Checked;
            dtLanguage.Rows.Add(dr);


            dr = dtLanguage.NewRow();
            dr["Id"] = "ca_french";
            dr["LanguageName"] = txtFrenchCA.Text;
            dr["IsVisible"] = chk_ca_french.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "fr_french";
            dr["LanguageName"] = txtFrenchFR.Text;
            dr["IsVisible"] = chk_fr_french.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "mx_spanish";
            dr["LanguageName"] = txtSpanishMX.Text;
            dr["IsVisible"] = chk_mx_spanish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "sp_spanish";
            dr["LanguageName"] = txtSpanishSpain.Text;
            dr["IsVisible"] = chk_sp_spanish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "portuguese";
            dr["LanguageName"] = txtus_english.Text;
            dr["IsVisible"] = chk_us_english.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "simp_chinese";
            dr["LanguageName"] = txtChinese.Text;
            dr["IsVisible"] = chk_simp_chinese.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "german";
            dr["LanguageName"] = txtGerman.Text;
            dr["IsVisible"] = chk_german.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "japanese";
            dr["LanguageName"] = txtJapanese.Text;
            dr["IsVisible"] = chk_japanese.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "russian";
            dr["LanguageName"] = txtRussian.Text;
            dr["IsVisible"] = chk_russian.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "danish";
            dr["LanguageName"] = txtDanish.Text;
            dr["IsVisible"] = chk_danish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "polish";
            dr["LanguageName"] = txtPolish.Text;
            dr["IsVisible"] = chk_polish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "swedish";
            dr["LanguageName"] = txtSwedish.Text;
            dr["IsVisible"] = chk_swedish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "finnish";
            dr["LanguageName"] = txtFinnish.Text;
            dr["IsVisible"] = chk_finnish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "korean";
            dr["LanguageName"] = txtKorean.Text;
            dr["IsVisible"] = chk_korean.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "italian";
            dr["LanguageName"] = txtItalian.Text;
            dr["IsVisible"] = chk_italian.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "dutch";
            dr["LanguageName"] = txtDutch.Text;
            dr["IsVisible"] = chk_dutch.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "indonesian";
            dr["LanguageName"] = txtIndonesian.Text;
            dr["IsVisible"] = chk_indonesian.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "greek";
            dr["LanguageName"] = txtGreek.Text;
            dr["IsVisible"] = chk_greek.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "hungarian";
            dr["LanguageName"] = txtHungarian.Text;
            dr["IsVisible"] = chk_hungarian.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "norwegian";
            dr["LanguageName"] = txtNorwegian.Text;
            dr["IsVisible"] = chk_norwegian.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "turkish";
            dr["LanguageName"] = txtTurkish.Text;
            dr["IsVisible"] = chk_turkish.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "arabic_rtl";
            dr["LanguageName"] = txtArabic.Text;
            dr["IsVisible"] = chk_arabic_rtl.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_01";
            dr["LanguageName"] = txtCustom01.Text;
            dr["IsVisible"] = chk_Custom01.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_02";
            dr["LanguageName"] = txtCustom02.Text;
            dr["IsVisible"] = chk_Custom02.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_03";
            dr["LanguageName"] = txtCustom03.Text;
            dr["IsVisible"] = chk_Custom03.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_04";
            dr["LanguageName"] = txtCustom04.Text;
            dr["IsVisible"] = chk_Custom04.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_05";
            dr["LanguageName"] = txtCustom05.Text;
            dr["IsVisible"] = chk_Custom05.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_06";
            dr["LanguageName"] = txtCustom06.Text;
            dr["IsVisible"] = chk_Custom06.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_07";
            dr["LanguageName"] = txtCustom07.Text;
            dr["IsVisible"] = chk_Custom07.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_08";
            dr["LanguageName"] = txtCustom08.Text;
            dr["IsVisible"] = chk_Custom08.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_09";
            dr["LanguageName"] = txtCustom09.Text;
            dr["IsVisible"] = chk_Custom09.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_10";
            dr["LanguageName"] = txtCustom10.Text;
            dr["IsVisible"] = chk_Custom10.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_11";
            dr["LanguageName"] = txtCustom11.Text;
            dr["IsVisible"] = chk_Custom11.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_12";
            dr["LanguageName"] = txtCustom12.Text;
            dr["IsVisible"] = chk_Custom12.Checked;
            dtLanguage.Rows.Add(dr);

            dr = dtLanguage.NewRow();
            dr["Id"] = "custom_13";
            dr["LanguageName"] = txtCustom13.Text;
            dr["IsVisible"] = chk_Custom13.Checked;
            dtLanguage.Rows.Add(dr);


            try
            {
                string languageXML = ConvertDataTableToXml(dtLanguage);
                int error;
                error = SystemLocaleBLL.UpdatetLocale(languageXML);
                if (error != -2)
                {
                    //Show success message
                    divSuccess.Style.Add("display", "block");
                    divError.Style.Add("display", "none");
                    divSuccess.InnerHtml = "Update Successfully";


                }
                else
                {
                    //Show error message 
                    divSuccess.Style.Add("display", "none");
                    divError.Style.Add("display", "block");
                    divError.InnerText = "Data not Updated";

                }

                //Call the business
                //Show the message successfully inserted

            }
            catch (Exception)
            {

            }
            
        }




        public string ClassToXML(SystemLocale locale)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(locale.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, locale);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

      

        
    }
}