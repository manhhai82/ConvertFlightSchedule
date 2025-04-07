namespace ConvertFlightSchedule
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tctMain = new System.Windows.Forms.TabControl();
            this.tpData = new System.Windows.Forms.TabPage();
            this.dgvFlightSchedule = new System.Windows.Forms.DataGridView();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.tbxConsole = new System.Windows.Forms.TextBox();
            this.tpTest = new System.Windows.Forms.TabPage();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.statStrip = new System.Windows.Forms.StatusStrip();
            this.tssLblNotice = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssProBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tssLblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tctMain.SuspendLayout();
            this.tpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightSchedule)).BeginInit();
            this.tpOutput.SuspendLayout();
            this.tpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.panel1.SuspendLayout();
            this.statStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tctMain
            // 
            this.tctMain.Controls.Add(this.tpData);
            this.tctMain.Controls.Add(this.tpOutput);
            this.tctMain.Controls.Add(this.tpTest);
            this.tctMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctMain.Location = new System.Drawing.Point(0, 54);
            this.tctMain.Name = "tctMain";
            this.tctMain.SelectedIndex = 0;
            this.tctMain.Size = new System.Drawing.Size(1008, 653);
            this.tctMain.TabIndex = 10;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.dgvFlightSchedule);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(1000, 627);
            this.tpData.TabIndex = 1;
            this.tpData.Text = "Dữ liệu";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // dgvFlightSchedule
            // 
            this.dgvFlightSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlightSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlightSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgvFlightSchedule.Name = "dgvFlightSchedule";
            this.dgvFlightSchedule.Size = new System.Drawing.Size(994, 621);
            this.dgvFlightSchedule.TabIndex = 0;
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.tbxConsole);
            this.tpOutput.Location = new System.Drawing.Point(4, 22);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutput.Size = new System.Drawing.Size(1000, 627);
            this.tpOutput.TabIndex = 0;
            this.tpOutput.Text = "Console";
            this.tpOutput.UseVisualStyleBackColor = true;
            // 
            // tbxConsole
            // 
            this.tbxConsole.AcceptsReturn = true;
            this.tbxConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxConsole.Location = new System.Drawing.Point(3, 3);
            this.tbxConsole.MaxLength = 0;
            this.tbxConsole.Multiline = true;
            this.tbxConsole.Name = "tbxConsole";
            this.tbxConsole.ReadOnly = true;
            this.tbxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxConsole.Size = new System.Drawing.Size(994, 621);
            this.tbxConsole.TabIndex = 8;
            // 
            // tpTest
            // 
            this.tpTest.Controls.Add(this.dgvTest);
            this.tpTest.Location = new System.Drawing.Point(4, 22);
            this.tpTest.Name = "tpTest";
            this.tpTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpTest.Size = new System.Drawing.Size(1000, 627);
            this.tpTest.TabIndex = 2;
            this.tpTest.Text = "Test";
            this.tpTest.UseVisualStyleBackColor = true;
            // 
            // dgvTest
            // 
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTest.Location = new System.Drawing.Point(3, 3);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.Size = new System.Drawing.Size(994, 621);
            this.dgvTest.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 54);
            this.panel1.TabIndex = 11;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Enabled = false;
            this.btnExport.Image = global::ConvertFlightSchedule.Properties.Resources.ButExport;
            this.btnExport.Location = new System.Drawing.Point(909, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 54);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất file";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImport.Image = global::ConvertFlightSchedule.Properties.Resources.ButImport;
            this.btnImport.Location = new System.Drawing.Point(0, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(99, 54);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập file";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // statStrip
            // 
            this.statStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLblNotice,
            this.tssProBar,
            this.tssLblVersion});
            this.statStrip.Location = new System.Drawing.Point(0, 707);
            this.statStrip.Name = "statStrip";
            this.statStrip.Size = new System.Drawing.Size(1008, 22);
            this.statStrip.TabIndex = 12;
            this.statStrip.Text = "statStrip";
            // 
            // tssLblNotice
            // 
            this.tssLblNotice.AutoSize = false;
            this.tssLblNotice.Name = "tssLblNotice";
            this.tssLblNotice.Size = new System.Drawing.Size(200, 17);
            this.tssLblNotice.Text = "Bắt đầu xuất file...";
            this.tssLblNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssLblNotice.Visible = false;
            // 
            // tssProBar
            // 
            this.tssProBar.AutoSize = false;
            this.tssProBar.Name = "tssProBar";
            this.tssProBar.Size = new System.Drawing.Size(150, 16);
            this.tssProBar.Visible = false;
            // 
            // tssLblVersion
            // 
            this.tssLblVersion.AutoSize = false;
            this.tssLblVersion.Name = "tssLblVersion";
            this.tssLblVersion.Size = new System.Drawing.Size(200, 17);
            this.tssLblVersion.Text = "v1.0.0";
            this.tssLblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tctMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statStrip);
            this.Name = "FormMain";
            this.Text = "Flight Schedule Convert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tctMain.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightSchedule)).EndInit();
            this.tpOutput.ResumeLayout(false);
            this.tpOutput.PerformLayout();
            this.tpTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statStrip.ResumeLayout(false);
            this.statStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tctMain;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.TextBox tbxConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.DataGridView dgvFlightSchedule;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.StatusStrip statStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssLblNotice;
        private System.Windows.Forms.ToolStripProgressBar tssProBar;
        private System.Windows.Forms.ToolStripStatusLabel tssLblVersion;
        private System.Windows.Forms.TabPage tpTest;
        private System.Windows.Forms.DataGridView dgvTest;
    }
}

