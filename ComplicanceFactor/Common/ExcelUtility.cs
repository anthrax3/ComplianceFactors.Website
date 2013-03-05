using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Extensions;


namespace ComplicanceFactor.Common
{
    public class ExcelUtility
    {
        public static MemoryStream GetStreamFromDataSet(DataSet ds)
        {
            MemoryStream stream = SpreadsheetReader.Create();
            using (SpreadsheetDocument spreadSheet =  SpreadsheetDocument.Open(stream, true))
            {
                uint worksheetNumber = 1;
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    WorksheetPart newWorkSheetPart =
                        spreadSheet.WorkbookPart.AddNewPart<WorksheetPart>();
                    newWorkSheetPart.Worksheet = new Worksheet(new SheetData());
                    newWorkSheetPart.Worksheet.Save();
                    Sheets sheets =
                        spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                    string relationshipId =
                        spreadSheet.WorkbookPart.GetIdOfPart(newWorkSheetPart);
                    uint sheetId = (uint)i;
                    if (sheets.Elements<Sheet>().Count() > 0)
                    {
                        sheetId = sheets.Elements<Sheet>().Select(s =>
                            s.SheetId.Value).Max() + 1;
                    }
                    Sheet sheet = new Sheet()
                    {
                        Id = relationshipId,
                        SheetId = sheetId,
                        Name = ds.Tables[i].TableName
                    };
                    sheets.Append(sheet);
                    //  For each worksheet you want to create
                    string workSheetID = "rId" + worksheetNumber.ToString();
                    string worksheetName = ds.Tables[i].TableName;
                    WriteDataTableToExcelWorksheet(ds.Tables[i], newWorkSheetPart);
                    worksheetNumber++;

                    spreadSheet.WorkbookPart.Workbook.Save();

                }

                //Remove first 3 default tabs (Sheet1 ~ Sheet3)
                spreadSheet.WorkbookPart.Workbook.Sheets.FirstChild.Remove();
                spreadSheet.WorkbookPart.Workbook.Sheets.FirstChild.Remove();
                spreadSheet.WorkbookPart.Workbook.Sheets.FirstChild.Remove();
            };
            return stream;
        }

        private static string GetExcelColumnValue(int columnNumber)
        {
            if (columnNumber <= 26)
            {
                return ((char)(columnNumber + 64)).ToString();
            }
            columnNumber--;
            return GetExcelColumnValue(columnNumber / 26) +
                GetExcelColumnValue((columnNumber % 26) + 1);
        }
        private static string GetExcelColumnName(int columnIndex)
        {

            if (columnIndex < 26)
                return ((char)('A' + columnIndex)).ToString();

            char firstChar = (char)('A' + (columnIndex / 26) - 1);
            char secondChar = (char)('A' + (columnIndex % 26));

            return string.Format("{0}{1}", firstChar, secondChar);
        }
        private static void WriteDataTableToExcelWorksheet(DataTable dt, WorksheetPart worksheetPart1)
        {
            Worksheet worksheet = new Worksheet();
            SheetViews sheetViews = new SheetViews();

            SheetView sheetView = new SheetView() { TabSelected = true, WorkbookViewId = (UInt32Value)0U };
            sheetViews.Append(sheetView);

            SheetData sheetData1 = new SheetData();

            string cellValue = "";

            //  Create a Header Row in our Excel file, containing one header for each Column of data in our DataTable.
            //
            //  We'll also create an array, showing which type each column of data is (Text or Numeric), so when we come to write the actual
            //  cells of data, we'll know if to write Text values or Numeric cell values.
            int numberOfColumns = dt.Columns.Count;
            bool[] IsNumericColumn = new bool[numberOfColumns];

            string[] excelColumnNames = new string[numberOfColumns];
            for (int n = 0; n < numberOfColumns; n++)
                excelColumnNames[n] = GetExcelColumnName(n);

            //
            //  Create the Header row in our Excel Worksheet
            //
            int rowIndex = 1;
            Row row1 = new Row() { RowIndex = (UInt32Value)1U };

            for (int colInx = 0; colInx < numberOfColumns; colInx++)
            {
                DataColumn col = dt.Columns[colInx];

                AppendTextCell(excelColumnNames[colInx] + "1", col.ColumnName, row1);
                IsNumericColumn[colInx] = (col.DataType.FullName == "System.Decimal");     //  eg "System.String" or "System.Decimal"
            }
            sheetData1.Append(row1);
            // Add the empty row.


            //
            //  Now, step through each row of data in our DataTable...
            //
            double cellNumericValue = 0;
            foreach (DataRow dr in dt.Rows)
            {
                // ...create a new row, and append a set of this row's data to it.
                ++rowIndex;
                Row newExcelRow = new Row() { RowIndex = (UInt32Value)(uint)rowIndex };

                for (int colInx = 0; colInx < numberOfColumns; colInx++)
                {
                    cellValue = dr.ItemArray[colInx].ToString();

                    if (IsNumericColumn[colInx])
                    {
                        //  For numeric cells, make sure our input data IS a number, then write it out to the Excel file.
                        cellNumericValue = 0;
                        double.TryParse(cellValue, out cellNumericValue);
                        cellValue = cellNumericValue.ToString();

                        AppendNumericCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
                    }
                    else
                    {
                        //  For text cells, just write the input data straight out to the Excel file.
                        AppendTextCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
                    }
                }
                sheetData1.Append(newExcelRow);
            }

            worksheet.Append(sheetViews);
            worksheet.Append(sheetData1);

            worksheetPart1.Worksheet = worksheet;
        }
        private static void AppendNumericCell(string cellReference, string cellStringValue, Row excelRow)
        {
            //  Add a new Excel Cell to our Row 
            Cell cell = new Cell() { CellReference = cellReference };
            CellValue cellValue = new CellValue();
            cellValue.Text = cellStringValue;
            cell.Append(cellValue);
            excelRow.Append(cell);
        }
        private static void AppendTextCell(string cellReference, string cellStringValue, Row excelRow)
        {
            //  Add a new Excel Cell to our Row 
            Cell cell = new Cell() { CellReference = cellReference, DataType = CellValues.String };
            CellValue cellValue = new CellValue();
            cellValue.Text = cellStringValue;
            cell.Append(cellValue);
            excelRow.Append(cell);
        }


    }
}