using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertFlightSchedule
{
    public partial class FormMain: Form
    {
        private DataTable dtFlighSchedule;
        //private BindingSource bsFlightSchedule;

        //private DataTable dtDay1Arr;
        //private DataTable dtDay1Dep;

        private DataTable[] dtDayArr;
        private DataTable[] dtDayDep;

        //private BackgroundWorker bgWorker;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
            btnExport.Enabled = false;
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            tssLblVersion.Text = "Version: " + version.ToString();
            //bgWorker = new BackgroundWorker();
            //bgWorker.DoWork += BgWorker_DoWork;
            //bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            //bgWorker.ProgressChanged += BgWorker_ProgressChanged;

            //bgWorker.WorkerReportsProgress = true;
            //bgWorker.WorkerSupportsCancellation = true;
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private string GetArrivalFlightNo(string strInput)
        {   
            string result ="";
            try
            {
                result = strInput.Trim().Substring(0, strInput.IndexOf("/")).Trim();
            }catch
            {
                throw new Exception("GetArrivalFlightNo");
            }
            return result;
        }
        private string GetArrivalRoute(string strInput)
        {
            string result = "";
            try
            {
                result = strInput.Trim().Substring(0, 7);
            }
            catch
            {
                throw new Exception("GetArrivalRoute");
            }
            return result;
        }
        private string GetArrivalSTD(string strInput)
        {
            string result = "";
            try
            {
                result = strInput.Trim().Substring(0, 4);
            }
            catch
            {
                throw new Exception("GetArrivalSTD");
            }
            return result;
        }
        private string GetDepartureFlightNo(string strInput)
        {
            string result = "";
            try
            {
                int indexOf = strInput.IndexOf("/")+1;
                result = strInput.Trim().Substring(indexOf, strInput.Length - indexOf).Trim();
            }
            catch
            {
                throw new Exception("GetDepartureFlightNo");
            }
            return result;
        }
        private string GetDepartureRoute(string strInput)
        {
            string result = "";
            try
            {
                result = strInput.Trim().Substring(strInput.Length-7, 7);
            }
            catch
            {
                throw new Exception("GetDepartureRoute");
            }
            return result;
        }
        private string GetDepartureSTD(string strInput)
        {
            string result = "";
            try
            {
                result = strInput.Trim().Substring(strInput.Length-4, 4);
            }
            catch
            {
                throw new Exception("GetDepartureSTD");
            }
            return result;
        }
        private void BeginConverting()
        {
            try
            {
                dtDayArr = new DataTable[7];
                dtDayDep = new DataTable[7];

                for (int dayIndex = 0; dayIndex < 7; dayIndex++)
                {
                    DataTable dtDay1 = dtFlighSchedule.Copy();
                    if (dtDay1.Columns.Count < 10)
                        throw new Exception("Lỗi dữ liệu, không đủ số lượng cột (10)");
                    for (int i = 9; i > 2; i--)
                    {
                        if (i != dayIndex + 3)
                            dtDay1.Columns.RemoveAt(i);
                    }
                    DataRow[] drSelect = dtDay1.Select("[" + dtDay1.Columns[3].ColumnName + "]='X'");

                    foreach (DataRow datRow in drSelect)
                        dtDay1.Rows.Remove(datRow);

                    DataTable dtDay1Arr = new DataTable();

                    for (int i = 0; i < 30; i++)
                        dtDay1Arr.Columns.Add();
                    dtDay1Arr.TableName = dtDay1.Columns[3].ColumnName;
                    dtDay1Arr.Columns[5].ColumnName = "ScheduledTime";
                    dtDay1Arr.Columns[6].ColumnName = "EstimatedTime";
                    dtDay1Arr.Columns[7].ColumnName = "ActualTime";
                    dtDay1Arr.Columns[8].ColumnName = "ChockTime";

                    DataTable dtDay1Dep = dtDay1Arr.Copy();


                    for (int i = 0; i < dtDay1.Rows.Count; i++)
                    {
                        DataRow datArrRow = dtDay1Arr.NewRow();
                        DataRow datDepRow = dtDay1Dep.NewRow();
                        for (int j = 0; j < dtDay1Arr.Columns.Count; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    datArrRow[j] = i + 1;
                                    datDepRow[j] = i + 1;
                                    break;
                                case 1:
                                    datArrRow[j] = GetArrivalFlightNo(dtDay1.Rows[i]["FLIGHT"].ToString());
                                    datDepRow[j] = GetDepartureFlightNo(dtDay1.Rows[i]["FLIGHT"].ToString());
                                    break;
                                case 4:
                                    datArrRow[j] = GetArrivalRoute(dtDay1.Rows[i]["ROUTE"].ToString());
                                    datDepRow[j] = GetDepartureRoute(dtDay1.Rows[i]["ROUTE"].ToString());
                                    break;
                                case 5:
                                    if (dtDay1.Rows[i][3].ToString().Trim() != "BT")
                                    {
                                        datArrRow[j] = GetArrivalSTD(dtDay1.Rows[i][3].ToString());
                                        datDepRow[j] = GetDepartureSTD(dtDay1.Rows[i][3].ToString());
                                    }
                                    else
                                    {
                                        datArrRow[j] = GetArrivalSTD(dtDay1.Rows[i]["STA/STD"].ToString());
                                        datDepRow[j] = GetDepartureSTD(dtDay1.Rows[i]["STA/STD"].ToString());
                                    }
                                    break;
                                default:
                                    datArrRow[j] = "";
                                    datDepRow[j] = "";
                                    break;
                            }

                        }
                        dtDay1Arr.Rows.Add(datArrRow);
                        dtDay1Dep.Rows.Add(datDepRow);
                    }

                    dtDay1Dep.Columns.RemoveAt(29);

                    dtDayArr[dayIndex] = dtDay1Arr;
                    dtDayDep[dayIndex] = dtDay1Dep;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //DataTable dtDay1 = dtFlighSchedule.Copy();
            //if (dtDay1.Columns.Count < 10)
            //    throw new Exception("Lỗi dữ liệu, không đủ số lượng cột (10)");
            //for (int i = 9; i > 3; i--)
            //    dtDay1.Columns.RemoveAt(i);
            //DataRow[] drSelect = dtDay1.Select("["+dtDay1.Columns[3].ColumnName + "]='X'");
            //foreach (DataRow datRow in drSelect)
            //    dtDay1.Rows.Remove(datRow);
            
            //dtDay1Arr = new DataTable();
            //for (int i=0;i<30;i++)
            //    dtDay1Arr.Columns.Add();
            //dtDay1Arr.TableName = dtFlighSchedule.Columns[3].ColumnName;
            //dtDay1Arr.Columns[5].ColumnName = "ScheduledTime";
            //dtDay1Arr.Columns[6].ColumnName = "EstimatedTime";
            //dtDay1Arr.Columns[7].ColumnName = "ActualTime";
            //dtDay1Arr.Columns[8].ColumnName = "ChockTime";

            //dtDay1Dep = dtDay1Arr.Copy();
            

            //for (int i=0; i<dtDay1.Rows.Count;i++)
            //{
            //    DataRow datArrRow = dtDay1Arr.NewRow();
            //    DataRow datDepRow = dtDay1Dep.NewRow();
            //    for (int j = 0; j < dtDay1Arr.Columns.Count; j++)
            //    {   
            //        switch (j)
            //        {
            //            case 0:
            //                datArrRow[j] = i + 1;
            //                datDepRow[j] = i + 1;
            //                break;
            //            case 1:
            //                datArrRow[j] = GetArrivalFlightNo(dtDay1.Rows[i]["FLIGHT"].ToString());
            //                datDepRow[j] = GetDepartureFlightNo(dtDay1.Rows[i]["FLIGHT"].ToString());
            //                break;
            //            case 4:
            //                datArrRow[j] = GetArrivalRoute(dtDay1.Rows[i]["ROUTE"].ToString());
            //                datDepRow[j] = GetDepartureRoute(dtDay1.Rows[i]["ROUTE"].ToString());
            //                break;
            //            case 5:
            //                if (dtDay1.Rows[i][3].ToString().Trim() != "BT")
            //                {
            //                    datArrRow[j] = GetArrivalSTD(dtDay1.Rows[i][3].ToString());
            //                    datDepRow[j] = GetDepartureSTD(dtDay1.Rows[i][3].ToString());
            //                }
            //                else
            //                {
            //                    datArrRow[j] = GetArrivalSTD(dtDay1.Rows[i]["STA/STD"].ToString());
            //                    datDepRow[j] = GetDepartureSTD(dtDay1.Rows[i]["STA/STD"].ToString());
            //                }
            //                break;
            //            default:
            //                datArrRow[j] = "";
            //                datDepRow[j] = "";
            //                break;
            //        }
                    
            //    }
            //    dtDay1Arr.Rows.Add(datArrRow);
            //    dtDay1Dep.Rows.Add(datDepRow);
            //}

            //dtDay1Dep.Columns.RemoveAt(29);

            //dgvTest.DataSource = dtDay1Dep;
            //tctMain.SelectedTab = tpTest;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDlg = new OpenFileDialog()
                {
                    Filter = "Microsoft Office Excel Files|*.xlsx",
                    Title = "Nhập liệu từ Excel"
                };
                if (fileDlg.ShowDialog() != DialogResult.Cancel)
                {
                    this.Cursor = Cursors.WaitCursor;
                    
                    string strFileName = fileDlg.FileName;
                    string[] arrExtension = strFileName.Split(new char[] { '.' });
                    string extension = arrExtension[(int)arrExtension.Length - 1];
                    if (extension.ToLower().Equals("xlsx"))
                    {
                        DisposeTables();
                        btnExport.Enabled = false;
                        FormSheetSelect formSheetSelect = new FormSheetSelect();
                        formSheetSelect.sheetNames = Helper.GetWorkSheets(strFileName);
                        this.Cursor = Cursors.Arrow;
                        if (formSheetSelect.ShowDialog()==DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            string sheetName = formSheetSelect.sheetName;
                            dtFlighSchedule = Helper.ConvertToDataTable(strFileName, sheetName);
                            if (dtFlighSchedule != null)
                            {
                                dgvFlightSchedule.DataSource = dtFlighSchedule;
                                if (dtFlighSchedule.Rows.Count > 0 && dtFlighSchedule.Columns.Count > 0)
                                {
                                    WriteToConsole("Đọc dữ liệu thành công từ sheet " + sheetName + ", file " + strFileName);
                                    WriteToConsole("Bắt đầu chuyển đổi dữ liệu...");
                                    
                                    BeginConverting();

                                    WriteToConsole("Chuyển đổi dữ liệu hoàn thành!");
                                    WriteToConsole("Sẵn sàng xuất file dữ liệu");
                                    btnExport.Enabled = true;
                                }
                                this.Cursor = Cursors.Arrow;
                            }
                            else
                            {
                               throw new Exception("File không đúng định dạng!");
                            }
                        }
                        

                    }
                    else
                    {
                        throw new Exception("File không đúng định dạng!");
                    }


                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                WriteToConsole(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void WriteToConsole(string Content)
        {
            tctMain.SelectedTab = tpOutput;

            if (tbxConsole.Lines.Length > 10000)
            {
                int numOfLines = 9999;
                var lines = this.tbxConsole.Lines;
                var newLines = lines.Skip(numOfLines);
                this.tbxConsole.Lines = newLines.ToArray();
            }
            
            tbxConsole.AppendText(Environment.NewLine + Content);
            clsLog WriteToLog = new clsLog(Content);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DisposeTables()
        {
            if (dtFlighSchedule != null)
            {
                dtFlighSchedule.Dispose();
                dtFlighSchedule = null;
            }
            //if (bsFlightSchedule != null)
            //{
            //    bsFlightSchedule.Dispose();
            //    bsFlightSchedule = null;
            //}
            //if (dtDay1Arr != null)
            //{
            //    dtDay1Arr.Dispose();
            //    dtDay1Arr = null;
            //}
            //if (dtDay1Dep != null)
            //{
            //    dtDay1Dep.Dispose();
            //    dtDay1Dep = null;
            //}
            if (dtDayArr != null)
            {
                foreach (DataTable datable in dtDayArr)
                {
                    if (datable != null)
                    {
                        datable.Dispose();
                    }
                }
                dtDayArr = null;
            }
            if (dtDayDep != null)
            {
                foreach (DataTable datable in dtDayDep)
                {
                    if (datable != null)
                    {
                        datable.Dispose();
                    }
                }
                dtDayDep = null;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeTables();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Chọn thư mục xuất file";
                folderBrowserDialog.SelectedPath = System.IO.Directory.GetCurrentDirectory();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    

                    //string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments); //System.IO.Directory.GetCurrentDirectory();
                    string currentPath = folderBrowserDialog.SelectedPath;

                    if (!System.IO.Directory.Exists(currentPath + @"\Exported\")) //if no folder then create one
                    {
                        System.IO.Directory.CreateDirectory(currentPath + @"\Exported\");
                        WriteToConsole("Tạo thư mục "+ currentPath + @"\Exported\" + " thành công!");
                        
                    }
                    if (!System.IO.Directory.Exists(currentPath + @"\Exported\Arrival\")) //if no folder then create one
                    {
                        System.IO.Directory.CreateDirectory(currentPath + @"\Exported\Arrival\");
                        WriteToConsole("Tạo thư mục " + currentPath + @"\Exported\Arrival\" + " thành công!");
                    }
                    if (!System.IO.Directory.Exists(currentPath + @"\Exported\Departure\")) //if no folder then create one
                    {
                        System.IO.Directory.CreateDirectory(currentPath + @"\Exported\Departure\");
                        WriteToConsole("Tạo thư mục " + currentPath + @"\Exported\Departure\" + " thành công!");
                    }
                    foreach (DataTable dtDay1Arr in dtDayArr)
                    {
                        string fileName = dtDay1Arr.TableName + " ARR" + " Flight Schedule.xlsx";

                        string day1ArrFileName = currentPath + @"\Exported\Arrival\" + fileName;

                        if (Helper.ExportToExcel(day1ArrFileName, "A", dtDay1Arr, dtDay1Arr.TableName) > 0)
                        {
                            WriteToConsole("Đã xuất file " + day1ArrFileName);
                        }

                    }
                    foreach (DataTable dtDay1Dep in dtDayDep)
                    { 
                        string fileName = dtDay1Dep.TableName + " DEP" + " Flight Schedule.xlsx";

                        string day1DepFileName = currentPath + @"\Exported\Departure\" + fileName;

                        if (Helper.ExportToExcel(day1DepFileName, "D", dtDay1Dep, dtDay1Dep.TableName) > 0)
                        {
                            WriteToConsole("Đã xuất file " + day1DepFileName);
                        }
                    }
                    WriteToConsole("Quá trình xuất file đã hoàn thành!");
                    //string day1ArrFileName = currentPath + @"\Exported\" + fileName;

                    //if (Helper.ExportToExcel(day1ArrFileName, "A", dtDay1Arr, dtDay1Arr.TableName) > 0)
                    //{
                    //    WriteToConsole("Đã xuất file " + day1ArrFileName);
                    //}

                    //fileName = dtDay1Dep.TableName + " DEP" + " Flight Schedule.xlsx";

                    //string day1DepFileName = currentPath + @"\Exported\" + fileName;
                    //if (Helper.ExportToExcel(day1DepFileName, "D", dtDay1Dep, dtDay1Dep.TableName) > 0)
                    //{
                    //    WriteToConsole("Đã xuất file " + day1DepFileName);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
    
}
