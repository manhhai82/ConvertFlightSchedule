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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.tbxConsole = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvFlightSchedule = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpOutput.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightSchedule)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpOutput);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 663);
            this.tabControl1.TabIndex = 10;
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.tbxConsole);
            this.tpOutput.Location = new System.Drawing.Point(4, 22);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutput.Size = new System.Drawing.Size(1000, 637);
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
            this.tbxConsole.Size = new System.Drawing.Size(994, 631);
            this.tbxConsole.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvFlightSchedule);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 637);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Dữ liệu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvFlightSchedule
            // 
            this.dgvFlightSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlightSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlightSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgvFlightSchedule.Name = "dgvFlightSchedule";
            this.dgvFlightSchedule.Size = new System.Drawing.Size(994, 631);
            this.dgvFlightSchedule.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 66);
            this.panel1.TabIndex = 11;
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImport.Image = global::ConvertFlightSchedule.Properties.Resources.ButImport;
            this.btnImport.Location = new System.Drawing.Point(0, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(127, 66);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "Flight Schedule Convert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpOutput.ResumeLayout(false);
            this.tpOutput.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightSchedule)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.TextBox tbxConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvFlightSchedule;
    }
}

