using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private BindingSource bsFlightSchedule;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

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
                    //bsOperationLevelTask.EndEdit();
                    string strFileName = fileDlg.FileName;
                    string[] arrExtension = strFileName.Split(new char[] { '.' });
                    string extension = arrExtension[(int)arrExtension.Length - 1];
                    if (extension.ToLower().Equals("xlsx"))
                    {
                        FormSheetSelect formSheetSelect = new FormSheetSelect(strFileName);
                        if (formSheetSelect.ShowDialog()==DialogResult.OK)
                        {
                            string sheetName = formSheetSelect.sheetName;
                            dtFlighSchedule = Helper.ConvertToDataTable(strFileName, sheetName);
                            if (dtFlighSchedule != null)
                            {
                                dgvFlightSchedule.DataSource = dtFlighSchedule;
                            }
                            else
                            {
                               throw new Exception("File không đúng định dạng!");
                            }
                        }
                        
                        //int currAssetCategoryID = 0;
                        //int.TryParse(cbbAssetCategory.SelectedValue.ToString(), out currAssetCategoryID);
                        //int currAssetID = 0;
                        //int.TryParse(cbbAssetList.SelectedValue.ToString(), out currAssetID);
                        //int currProcedureID = 0;
                        //int.TryParse(cbbProcedure.SelectedValue.ToString(), out currProcedureID);
                        //int currFormID = 0;
                        //int.TryParse(cbbForms.SelectedValue.ToString(), out currFormID);
                        //DataRowView currentOperationLevel = bsOperationLevel.Current as DataRowView;
                        //int currentOperationLevelID = 0;
                        //int.TryParse(currentOperationLevel["OpLevelID"].ToString(), out currentOperationLevelID);
                        ////string currFormCode = dvGeneralFormRef[cbbForms.SelectedIndex]["FormCode"].ToString();
                        ////string currFormName = dvGeneralFormRef[cbbForms.SelectedIndex]["FormName"].ToString();
                        ////result = businessLayer.ImportOperationLevelTaskByExcelFile(strFileName, currentOperationLevel["OpLevelCode"].ToString(),
                        //result = businessLayer.ImportOperationLevelTaskByExcelFile(strFileName, "OpLevelID_" + currentOperationLevelID.ToString(),
                        //    currAssetCategoryID, currAssetID, currentOperationLevelID, currProcedureID, currFormID, DateTime.Now, CurrentEmployee.EmployeeID);
                        //if (result == -1)
                        //{
                        //    MessageBox.Show(this, "Lỗi định dạng file Excel!", "Lỗi");
                        //}
                        //if (result > 0)
                        //{
                        //    MessageBox.Show(this, "(" + result.ToString() + ") dòng đã nhập thành công!", "Message");

                        //    WriteToConsole(" tasks!");
                        //    //ReloadTaskGrid();
                        //}

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
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void WriteToConsole(string Content)
        {
            if (tbxConsole.Lines.Length > 10000)
            {
                int numOfLines = 9999;
                var lines = this.tbxConsole.Lines;
                var newLines = lines.Skip(numOfLines);
                this.tbxConsole.Lines = newLines.ToArray();
            }
            //tbxConsole.Text = Content + Environment.NewLine + tbxConsole.Text;
            tbxConsole.AppendText(Environment.NewLine + Content);
            clsLog WriteToLog = new clsLog(Content);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dtFlighSchedule != null)
            {
                dtFlighSchedule.Dispose();
                dtFlighSchedule = null;
            }
            if (bsFlightSchedule != null)
            {
                bsFlightSchedule.Dispose();
                bsFlightSchedule = null;
            }
        }
    }
    
}
