using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S = DocumentFormat.OpenXml.Spreadsheet.Sheets;
using E = DocumentFormat.OpenXml.OpenXmlElement;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Spreadsheet;
using NormalizaNomes.Extensions;

namespace NormalizaNomes
{
    public class RowUpdated
    {
        public string Ra { get; set; }
        public string Oldvalue { get; set; }
        public string NewValue { get; set; }

        public override string ToString()
        {
            return $"{Ra}\t{Oldvalue}\t{NewValue}";
        }
    }

    public enum LogType
    {
        Trace,
        Information,
        Error,
    }

    class SheetService
    {
        private readonly Action<LogType, string> Log;

        public SheetService(Action<LogType, string> log)
        {
            Log = log;
        }

        public async Task Execute(string filePath, bool save)
        {
            using (SpreadsheetDocument mySpreadsheet = SpreadsheetDocument.Open(filePath, true))
            {
                S sheets = mySpreadsheet.WorkbookPart.Workbook.Sheets;

                // For each sheet, display the sheet information.
                foreach (E sheet in sheets)
                {
                    var sheetName = string.Empty;
                    try
                    {
                        sheetName = sheet.GetAttributes().First(c => c.LocalName == "name").Value;
                        //verifica se o nome da planilha contem somente números.

                        if (!Regex.IsMatch(sheetName, @"^[0-9]+$"))
                        {
                            Log(LogType.Information, $"Planilha {sheetName} ignorada");
                            continue;
                        }

                        Log(LogType.Trace, $"Planilha {sheetName} - iniciando processamento");
                        var sheetId = sheet.GetAttributes().First(c => c.LocalName == "id").Value;


                        var qtdRowFounded = await ReadExcelSheet(mySpreadsheet, sheetId, save);
                        Log(LogType.Trace, $"Planilha {sheetName} - fim processamento, {qtdRowFounded} linhas foram alteradas.");
                    }
                    catch (Exception ex)
                    {
                        Log(LogType.Error, "Ocorreu um erro");
                    }
                }
                if (save)
                    mySpreadsheet.Save();

                mySpreadsheet.Close();
            }
        }

        private async Task<int> ReadExcelSheet(SpreadsheetDocument doc, string workSheetId, bool save)
        {
            int i = 0;
            var workpart = (doc.WorkbookPart.GetPartById(workSheetId) as WorksheetPart);
            var worksheet = workpart.Worksheet;

            if (workpart == null) return i;

            var rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>().Skip(6);

            foreach (var row in rows)
            {
                var cell = row.Descendants<Cell>().ElementAt(1);
                var value = GetCellValue(doc, cell);

                if (string.IsNullOrEmpty(value)) break;

                if (!value.IsUpper())
                {
                    var cellUpdated = value.ToUpper();

                    var logObject = new RowUpdated
                    {
                        Ra = row.Descendants<Cell>().ElementAt(0).InnerText,
                        Oldvalue = value,
                        NewValue = cellUpdated
                    };

                    if (save)
                        cell.CellValue = new CellValue(cellUpdated);

                    Log(LogType.Trace, logObject.ToString());
                    i++;
                }
            }

            return await Task.FromResult(i);
        }

        private string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            if (cell is null) return string.Empty;

            string value = cell.CellValue?.InnerText;
            if (cell?.DataType != null && cell?.DataType.Value == CellValues.SharedString)
                return doc.WorkbookPart?.SharedStringTablePart?.SharedStringTable?.ChildElements?.GetItem(int.Parse(value))?.InnerText;

            return value;
        }

        // Retrieve the value of a cell, given a file name, sheet name, 
        // and address name.
        public string GetCellValue(SpreadsheetDocument document,
                                          string sheetName,
                                          string addressName)
        {
            string value = null;
            // Retrieve a reference to the workbook part.
            WorkbookPart wbPart = document.WorkbookPart;

            // Find the sheet with the supplied name, and then use that 
            // Sheet object to retrieve a reference to the first worksheet.
            Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
              Where(s => s.Name == sheetName).FirstOrDefault();

            // Throw an exception if there is no sheet.
            if (theSheet == null)
                throw new ArgumentException("sheetName");

            // Retrieve a reference to the worksheet part.
            WorksheetPart wsPart =
                (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

            // Use its Worksheet property to get a reference to the cell 
            // whose address matches the address you supplied.
            Cell theCell = wsPart.Worksheet.Descendants<Cell>().
              Where(c => c.CellReference == addressName).FirstOrDefault();

            // If the cell does not exist, return an empty string.
            if (theCell != null)
            {
                value = theCell.InnerText;

                // If the cell represents an integer number, you are done. 
                // For dates, this code returns the serialized value that 
                // represents the date. The code handles strings and 
                // Booleans individually. For shared strings, the code 
                // looks up the corresponding value in the shared string 
                // table. For Booleans, the code converts the value into 
                // the words TRUE or FALSE.
                if (theCell.DataType != null)
                {
                    switch (theCell.DataType.Value)
                    {
                        case CellValues.SharedString:

                            // For shared strings, look up the value in the
                            // shared strings table.
                            var stringTable =
                                wbPart.GetPartsOfType<SharedStringTablePart>()
                                .FirstOrDefault();

                            // If the shared string table is missing, something 
                            // is wrong. Return the index that is in
                            // the cell. Otherwise, look up the correct text in 
                            // the table.
                            if (stringTable != null)
                            {
                                value =
                                    stringTable.SharedStringTable
                                    .ElementAt(int.Parse(value)).InnerText;
                            }
                            break;

                        case CellValues.Boolean:
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                default:
                                    value = "TRUE";
                                    break;
                            }
                            break;
                    }
                }
            }
            return value;
        }
    }
}
