namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    partial class ChangeBookingUS
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpNew = new System.Windows.Forms.GroupBox();
            this.lblNewTotal = new System.Windows.Forms.Label();
            this.numGuests = new System.Windows.Forms.NumericUpDown();
            this.lblGuests = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblCurrentDetails = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.lblRefLabel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGuests)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gray;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(708, 502);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(171, 39);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "✅ Update Booking";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.grpNew);
            this.pnlMain.Controls.Add(this.lblCurrentDetails);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Location = new System.Drawing.Point(194, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(674, 480);
            this.pnlMain.TabIndex = 4;
            // 
            // grpNew
            // 
            this.grpNew.BackColor = System.Drawing.Color.White;
            this.grpNew.Controls.Add(this.lblNewTotal);
            this.grpNew.Controls.Add(this.numGuests);
            this.grpNew.Controls.Add(this.lblGuests);
            this.grpNew.Controls.Add(this.dtpCheckOut);
            this.grpNew.Controls.Add(this.lblCheckOut);
            this.grpNew.Controls.Add(this.dtpCheckIn);
            this.grpNew.Controls.Add(this.lblCheckIn);
            this.grpNew.Enabled = false;
            this.grpNew.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpNew.Location = new System.Drawing.Point(26, 325);
            this.grpNew.Name = "grpNew";
            this.grpNew.Size = new System.Drawing.Size(634, 165);
            this.grpNew.TabIndex = 2;
            this.grpNew.TabStop = false;
            this.grpNew.Text = "New Booking Details";
            // 
            // lblNewTotal
            // 
            this.lblNewTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNewTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblNewTotal.Location = new System.Drawing.Point(16, 127);
            this.lblNewTotal.Name = "lblNewTotal";
            this.lblNewTotal.Size = new System.Drawing.Size(343, 26);
            this.lblNewTotal.TabIndex = 6;
            this.lblNewTotal.Text = "New Total: R 0.00";
            // 
            // numGuests
            // 
            this.numGuests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numGuests.Location = new System.Drawing.Point(129, 87);
            this.numGuests.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numGuests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGuests.Name = "numGuests";
            this.numGuests.Size = new System.Drawing.Size(86, 25);
            this.numGuests.TabIndex = 5;
            this.numGuests.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblGuests
            // 
            this.lblGuests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGuests.Location = new System.Drawing.Point(12, 89);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(111, 22);
            this.lblGuests.TabIndex = 4;
            this.lblGuests.Text = "Number of Guests:";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCheckOut.Location = new System.Drawing.Point(311, 45);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(230, 25);
            this.dtpCheckOut.TabIndex = 3;
            this.dtpCheckOut.Value = new System.DateTime(2025, 10, 13, 0, 0, 0, 0);
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckOut.Location = new System.Drawing.Point(307, 20);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(111, 22);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "New Check-Out:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCheckIn.Location = new System.Drawing.Point(21, 45);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(231, 25);
            this.dtpCheckIn.TabIndex = 1;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckIn.Location = new System.Drawing.Point(20, 23);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(103, 22);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "New Check-In:";
            // 
            // lblCurrentDetails
            // 
            this.lblCurrentDetails.BackColor = System.Drawing.Color.White;
            this.lblCurrentDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentDetails.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblCurrentDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblCurrentDetails.Location = new System.Drawing.Point(26, 95);
            this.lblCurrentDetails.Name = "lblCurrentDetails";
            this.lblCurrentDetails.Padding = new System.Windows.Forms.Padding(17);
            this.lblCurrentDetails.Size = new System.Drawing.Size(635, 214);
            this.lblCurrentDetails.TabIndex = 1;
            this.lblCurrentDetails.Text = "Search for a booking using the reference number...";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtReferenceNumber);
            this.pnlSearch.Controls.Add(this.lblRefLabel);
            this.pnlSearch.Location = new System.Drawing.Point(26, 17);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(634, 61);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(489, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferenceNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtReferenceNumber.Location = new System.Drawing.Point(163, 17);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(317, 27);
            this.txtReferenceNumber.TabIndex = 1;
            // 
            // lblRefLabel
            // 
            this.lblRefLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRefLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRefLabel.Location = new System.Drawing.Point(17, 20);
            this.lblRefLabel.Name = "lblRefLabel";
            this.lblRefLabel.Size = new System.Drawing.Size(137, 22);
            this.lblRefLabel.TabIndex = 0;
            this.lblRefLabel.Text = "Reference Number:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(221, 502);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(153, 39);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Reset Fields";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ChangeBookingUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pnlMain);
            this.Name = "ChangeBookingUS";
            this.Size = new System.Drawing.Size(1100, 600);
            this.pnlMain.ResumeLayout(false);
            this.grpNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGuests)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpNew;
        private System.Windows.Forms.Label lblNewTotal;
        private System.Windows.Forms.NumericUpDown numGuests;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblCurrentDetails;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label lblRefLabel;
        private System.Windows.Forms.Button btnClear;
    }
}
