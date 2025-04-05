
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

                    dt.Columns.Add(Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2));

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

                        row[i - 1] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, i]).Value2);

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

        //public static DataTable ImportOperationLevelTaskByExcelFile(string fileName, string sheetName, int AssetCategoryID, int AssetID, int OperationLevelID, int ProcedureID, int FormID, DateTime LastUpdate, int LastUpdaterID)
        //{
        //    try
        //    {
        //        int num = 0;
        //        DataTable dataTable1 = ConvertToDataTable(fileName, sheetName);
        //        for (int index = 0; index < dataTable1.Columns.Count; ++index)
        //        {
        //            if (dataTable1.Columns[index].ColumnName.Equals("STT"))
        //                ++num;
        //            else if (dataTable1.Columns[index].ColumnName.Equals("NỘI DUNG KIỂM TRA HÀNG NGÀY"))
        //                ++num;

        //        }
        //        if (num < 2)
        //            return -1;
        //        num = 0;
        //        for (int index = 0; index < dataTable1.Rows.Count; ++index)
        //        {
        //            DataRow row = dataTable1.Rows[index];
        //            string str1 = row["STT"].ToString().Trim();
        //            string str2 = row["NỘI DUNG KIỂM TRA HÀNG NGÀY"].ToString().Trim();

        //            SqlCommand sCommand = new SqlCommand("Ins_vcaOperationLevelTask");
        //            sCommand.CommandType = CommandType.StoredProcedure;
        //            SqlParameter sqlParameter1 = new SqlParameter("@TaskSerial", SqlDbType.NVarChar, 100);
        //            sqlParameter1.Value = str1;
        //            sCommand.Parameters.Add(sqlParameter1);
        //            SqlParameter sqlParameter2 = new SqlParameter("@TaskContent", SqlDbType.NVarChar, 500);
        //            sqlParameter2.Value = str2;
        //            sCommand.Parameters.Add(sqlParameter2);


        //            SqlParameter sqlParameter7 = new SqlParameter("@AssetCategoryID", SqlDbType.Int, 0);
        //            sqlParameter7.Value = AssetCategoryID;
        //            sCommand.Parameters.Add(sqlParameter7);
        //            SqlParameter sqlParameter8 = new SqlParameter("@AssetID", SqlDbType.Int, 0);
        //            sqlParameter8.Value = AssetID;
        //            sCommand.Parameters.Add(sqlParameter8);
        //            SqlParameter sqlParameter9 = new SqlParameter("@OperationLevelID", SqlDbType.Int, 0);
        //            sqlParameter9.Value = OperationLevelID;
        //            sCommand.Parameters.Add(sqlParameter9);
        //            SqlParameter sqlParameter10 = new SqlParameter("@ProcedureID", SqlDbType.Int, 0);
        //            sqlParameter10.Value = ProcedureID;
        //            sCommand.Parameters.Add(sqlParameter10);
        //            SqlParameter sqlParameter11 = new SqlParameter("@FormID", SqlDbType.Int, 0);
        //            sqlParameter11.Value = FormID;
        //            sCommand.Parameters.Add(sqlParameter11);
        //            SqlParameter sqlParameter12 = new SqlParameter("@LastUpdate", SqlDbType.DateTime, 0);
        //            sqlParameter12.Value = LastUpdate;
        //            sCommand.Parameters.Add(sqlParameter12);
        //            SqlParameter sqlParameter13 = new SqlParameter("@LastUpdaterID", SqlDbType.Int, 0);
        //            sqlParameter13.Value = LastUpdaterID;
        //            sCommand.Parameters.Add(sqlParameter13);

        //            /*qlParameter result = new SqlParameter("@Result", SqlDbType.Int, 0)
        //            {
        //                Value = 0,
        //                Direction = ParameterDirection.ReturnValue
        //            };
        //            sCommand.Parameters.Add(result);*/
        //            //int rowCount = dataLayer.ExecuteCommand(sCommand);
        //            //if (rowCount < 0)
        //            //    rowCount *= -1;
        //            ////int entryID = (int)result.Value;
        //            //num = num + rowCount;
        //            //sCommand.Dispose();
        //        }
        //        return num;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static int ExportToExcel(string ExcelFilePath, string FlightType, System.Data.DataTable dtFlightData, DateTime dateToExport)
        {
            int result = 0;
            Excel._Application xlsApp = null;
            Excel._Workbook xlsWorkBook = null;
            Excel._Worksheet xlsWorkSheet = null;
            try
            {
                
                object missValue = System.Reflection.Missing.Value;
                string templateFileName = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\" + (FlightType == "A" ? "Arrival" : "Departure") + " Template.xltx";
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
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Object);
                Object = null;
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
