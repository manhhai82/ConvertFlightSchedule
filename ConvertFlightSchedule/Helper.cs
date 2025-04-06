
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConvertFlightSchedule
{
    class Helper
    {
        public static string[] GetWorkSheets(string path)
        {
            string[] sheetNames = null;
            Excel.Application app = null;
            Excel.Workbook workBook = null;
            try
            {
                app = new Excel.Application();
                workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true,
                    Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                sheetNames = new string[workBook.Worksheets.Count];
                for (int i = 0; i < workBook.Worksheets.Count; i++)
                {
                    sheetNames[i] = ((Excel.Worksheet)workBook.Worksheets[i + 1]).Name;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                workBook.Close();
                app.Quit();
                ReleaseObject(workBook);
                ReleaseObject(app);
            }
            return sheetNames;
        }
        private static DateTime ConvertExcelDateToDateTime(double excelDate)
        {
            // Excel's base date is 1900-01-01
            DateTime excelBaseDate = new DateTime(1900, 1, 1);

            // Excel dates are stored as the number of days since 1900-01-01
            // If there is a time part, it will be represented as a fraction of a day.
            DateTime result = excelBaseDate.AddDays(excelDate - 2);  // Subtract 2 because Excel incorrectly treats 1900 as a leap year.

            return result;
        }
        public static System.Data.DataTable ConvertToDataTable(string path, string sheetName)

        {

            System.Data.DataTable dt = null;
            Excel.Application app = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            try

            {

                object rowIndex = 1;

                dt = new System.Data.DataTable();

                DataRow row;

                app = new Excel.Application();

                workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true,

                    Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                //Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
                workSheet = (Excel.Worksheet)workBook.Worksheets[sheetName];

                int temp = 1;

                while (((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)

                {
                    if (((Excel.Range)workSheet.Cells[rowIndex, temp]).Value.GetType() == typeof(DateTime))
                    {
                        double excelDate = Convert.ToDouble(((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2);
                        DateTime dateValue = ConvertExcelDateToDateTime(excelDate);
                        dt.Columns.Add(dateValue.ToString("yyyy-MM-dd"));
                    }
                    else
                        dt.Columns.Add(Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2).Trim().ToUpper());
                    
                    temp++;

                }

                rowIndex = Convert.ToInt32(rowIndex) + 1;

                int columnCount = temp;

                temp = 1;

                while (((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)

                {

                    row = dt.NewRow();

                    for (int i = 1; i < columnCount; i++)

                    {

                        row[i - 1] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, i]).Value2).Trim().ToUpper();

                    }

                    dt.Rows.Add(row);

                    rowIndex = Convert.ToInt32(rowIndex) + 1;

                    temp = 1;

                }
                
            }

            catch (Exception ex)

            {
                throw ex;
                //lblError.Text = ex.Message;

            }
            finally
            {
                workBook.Close();
                app.Workbooks.Close();
                app.Quit();
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(app);
            }

            return dt;

        }
        
        public static int ExportToExcel(string ExcelFilePath, string FlightType, System.Data.DataTable dtFlightData, DateTime dateToExport)
        {
            int result = 0;
            Excel._Application xlsApp = null;
            Excel._Workbook xlsWorkBook = null;
            Excel._Worksheet xlsWorkSheet = null;
            try
            {
                
                object missValue = System.Reflection.Missing.Value;
                //string templateFileName = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\" + (FlightType == "A" ? "Arrival" : "Departure") + " Template.xltx";
                string currentPath = System.IO.Directory.GetCurrentDirectory();
                string templateFileName = currentPath + @"\Templates\" + (FlightType == "A" ? "Arrival" : "Departure") + " Template.xltx";
                Console.WriteLine(templateFileName);
                xlsApp = new Excel.Application();
                xlsWorkBook = xlsApp.Workbooks.Add(templateFileName);
                xlsWorkSheet = xlsWorkBook.Worksheets.get_Item(1) as Excel.Worksheet;
                int xlsRowIndex = 12;
                int xlsColIndex = 2;
                for (int i = 0; i <= dtFlightData.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dtFlightData.Columns.Count - 1; j++)
                    {
                        if (dtFlightData.Rows[i][j] != null)
                        {
                            if (dtFlightData.Columns[j].ColumnName.EndsWith("Time"))
                            {
                                xlsWorkSheet.Cells[xlsRowIndex, xlsColIndex] = "'" + dtFlightData.Rows[i][j].ToString();
                            }
                            else
                                xlsWorkSheet.Cells[xlsRowIndex, xlsColIndex] = dtFlightData.Rows[i][j].ToString();
                        }
                        xlsColIndex++;
                    }
                    xlsColIndex = 2;
                    xlsRowIndex++;
                }
                xlsWorkSheet.Cells[6, 16] = "'" + dateToExport.ToString("dd-MMM-yyyy");
                xlsApp.DisplayAlerts = false;
                xlsWorkBook.SaveAs(ExcelFilePath, missValue, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, missValue, missValue, missValue, missValue);
                xlsWorkBook.Close(true, missValue, missValue);

                result++;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                xlsApp.Quit();
                ReleaseObject(xlsWorkSheet);
                ReleaseObject(xlsWorkBook);
                ReleaseObject(xlsApp);
            }
            return result;
        }
        static private void ReleaseObject(object Object)
        {
            try
            {
                if (Object != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Object);
                    Object = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
