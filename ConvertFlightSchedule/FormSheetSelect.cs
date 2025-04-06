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
    public partial class FormSheetSelect: Form
    {
        public string[] sheetNames { get; set; }
        public string sheetName { get; set; }

        public string fileName { get; set; }

        public FormSheetSelect()
        {
            InitializeComponent();
            fileName = "";
        }

        public FormSheetSelect(string strFileName)
        {
            InitializeComponent();
            fileName = strFileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbxSheets.SelectedItem != null)
            {
                sheetName = lbxSheets.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sheet cần chuyển đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormSheetSelect_Load(object sender, EventArgs e)
        {
            if (sheetNames==null)
                sheetNames = Helper.GetWorkSheets(fileName);
            if (sheetNames != null)
            {
                lbxSheets.DataSource = sheetNames;
            }
        }

    }
}
