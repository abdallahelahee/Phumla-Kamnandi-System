namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    partial class ReportsUS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.grpDateRange = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateOccupancy = new System.Windows.Forms.Button();
            this.btnGenerateRevenue = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.pnlMain.SuspendLayout();
            this.grpDateRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.formsPlot1);
            this.pnlMain.Controls.Add(this.grpDateRange);
            this.pnlMain.Controls.Add(this.btnGenerateOccupancy);
            this.pnlMain.Controls.Add(this.btnGenerateRevenue);
            this.pnlMain.Controls.Add(this.dgvReport);
            this.pnlMain.Location = new System.Drawing.Point(13, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1084, 597);
            this.pnlMain.TabIndex = 3;
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 0F;
            this.formsPlot1.Location = new System.Drawing.Point(26, 93);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1022, 302);
            this.formsPlot1.TabIndex = 5;
            // 
            // grpDateRange
            // 
            this.grpDateRange.BackColor = System.Drawing.Color.White;
            this.grpDateRange.Controls.Add(this.dtpStartDate);
            this.grpDateRange.Controls.Add(this.dtpEndDate);
            this.grpDateRange.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpDateRange.Location = new System.Drawing.Point(26, 3);
            this.grpDateRange.Name = "grpDateRange";
            this.grpDateRange.Size = new System.Drawing.Size(672, 69);
            this.grpDateRange.TabIndex = 0;
            this.grpDateRange.TabStop = false;
            this.grpDateRange.Text = "Select Date Range";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartDate.Location = new System.Drawing.Point(103, 29);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(230, 25);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Value = new System.DateTime(2025, 12, 1, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEndDate.Location = new System.Drawing.Point(383, 29);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(230, 25);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.Value = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            // 
            // btnGenerateOccupancy
            // 
            this.btnGenerateOccupancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerateOccupancy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateOccupancy.FlatAppearance.BorderSize = 0;
            this.btnGenerateOccupancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateOccupancy.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerateOccupancy.ForeColor = System.Drawing.Color.White;
            this.btnGenerateOccupancy.Location = new System.Drawing.Point(704, 18);
            this.btnGenerateOccupancy.Name = "btnGenerateOccupancy";
            this.btnGenerateOccupancy.Size = new System.Drawing.Size(189, 39);
            this.btnGenerateOccupancy.TabIndex = 2;
            this.btnGenerateOccupancy.Text = "📈 Occupancy Report";
            this.btnGenerateOccupancy.UseVisualStyleBackColor = false;
            this.btnGenerateOccupancy.Click += new System.EventHandler(this.btnGenerateOccupancy_Click);
            // 
            // btnGenerateRevenue
            // 
            this.btnGenerateRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGenerateRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateRevenue.FlatAppearance.BorderSize = 0;
            this.btnGenerateRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateRevenue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerateRevenue.ForeColor = System.Drawing.Color.White;
            this.btnGenerateRevenue.Location = new System.Drawing.Point(895, 18);
            this.btnGenerateRevenue.Name = "btnGenerateRevenue";
            this.btnGenerateRevenue.Size = new System.Drawing.Size(189, 39);
            this.btnGenerateRevenue.TabIndex = 3;
            this.btnGenerateRevenue.Text = "💰 Revenue Report";
            this.btnGenerateRevenue.UseVisualStyleBackColor = false;
            this.btnGenerateRevenue.Click += new System.EventHandler(this.btnGenerateRevenue_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersHeight = 35;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point(26, 401);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(1022, 178);
            this.dgvReport.TabIndex = 4;
            // 
            // ReportsUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ReportsUS";
            this.Size = new System.Drawing.Size(1100, 600);
            this.pnlMain.ResumeLayout(false);
            this.grpDateRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpDateRange;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnGenerateOccupancy;
        private System.Windows.Forms.Button btnGenerateRevenue;
        private System.Windows.Forms.DataGridView dgvReport;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}
