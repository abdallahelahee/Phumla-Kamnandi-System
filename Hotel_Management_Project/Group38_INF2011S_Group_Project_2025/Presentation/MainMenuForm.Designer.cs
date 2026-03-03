namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    partial class MainMenuForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pnlMover = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnEnquiry = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnChangeBooking = new System.Windows.Forms.Button();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterText = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.btnExit1);
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.pnlMover);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(153, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1157, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnExit1
            // 
            this.btnExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnExit1.BackgroundImage = global::Group38_INF2011S_Group_Project_2025.Properties.Resources.button;
            this.btnExit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit1.FlatAppearance.BorderSize = 0;
            this.btnExit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExit1.ForeColor = System.Drawing.Color.Black;
            this.btnExit1.Location = new System.Drawing.Point(1044, 20);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(39, 36);
            this.btnExit1.TabIndex = 0;
            this.btnExit1.UseVisualStyleBackColor = false;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = global::Group38_INF2011S_Group_Project_2025.Properties.Resources.minus;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(999, 21);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(39, 36);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlMover
            // 
            this.pnlMover.BackColor = System.Drawing.Color.White;
            this.pnlMover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMover.Location = new System.Drawing.Point(0, 0);
            this.pnlMover.Name = "pnlMover";
            this.pnlMover.Size = new System.Drawing.Size(1095, 13);
            this.pnlMover.TabIndex = 2;
            this.pnlMover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMover_MouseDown);
            this.pnlMover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMover_MouseMove);
            this.pnlMover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMover_MouseUp);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblSubtitle.Location = new System.Drawing.Point(277, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(514, 26);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Booking Management System";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(264, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(514, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHUMLA KAMNANDI HOTELS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 127);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Group38_INF2011S_Group_Project_2025.Properties.Resources.KeyLogo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlMain.Controls.Add(this.pnlNav);
            this.pnlMain.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.pnlMain.Location = new System.Drawing.Point(0, 125);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(154, 563);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlNav.Controls.Add(this.btnReports);
            this.pnlNav.Controls.Add(this.btnEnquiry);
            this.pnlNav.Controls.Add(this.btnCancelBooking);
            this.pnlNav.Controls.Add(this.btnChangeBooking);
            this.pnlNav.Controls.Add(this.btnMakeBooking);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(154, 560);
            this.pnlNav.TabIndex = 1;
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReports.Location = new System.Drawing.Point(0, 175);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(154, 46);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "📊View Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnEnquiry
            // 
            this.btnEnquiry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnquiry.FlatAppearance.BorderSize = 0;
            this.btnEnquiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnquiry.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEnquiry.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEnquiry.Location = new System.Drawing.Point(0, 46);
            this.btnEnquiry.Name = "btnEnquiry";
            this.btnEnquiry.Size = new System.Drawing.Size(154, 46);
            this.btnEnquiry.TabIndex = 3;
            this.btnEnquiry.Text = "🔍Booking Enquiry";
            this.btnEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnquiry.UseVisualStyleBackColor = true;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.FlatAppearance.BorderSize = 0;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelBooking.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelBooking.Location = new System.Drawing.Point(0, 132);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(154, 46);
            this.btnCancelBooking.TabIndex = 2;
            this.btnCancelBooking.Text = "❌Cancel Booking";
            this.btnCancelBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnChangeBooking
            // 
            this.btnChangeBooking.FlatAppearance.BorderSize = 0;
            this.btnChangeBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeBooking.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnChangeBooking.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChangeBooking.Location = new System.Drawing.Point(0, 89);
            this.btnChangeBooking.Name = "btnChangeBooking";
            this.btnChangeBooking.Size = new System.Drawing.Size(154, 46);
            this.btnChangeBooking.TabIndex = 1;
            this.btnChangeBooking.Text = "✏️Edit Booking";
            this.btnChangeBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeBooking.UseVisualStyleBackColor = true;
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMakeBooking.FlatAppearance.BorderSize = 0;
            this.btnMakeBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBooking.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMakeBooking.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMakeBooking.Location = new System.Drawing.Point(0, 0);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(154, 46);
            this.btnMakeBooking.TabIndex = 0;
            this.btnMakeBooking.Text = "📋 Make Booking";
            this.btnMakeBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblFooterText);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 687);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1248, 52);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooterText
            // 
            this.lblFooterText.AutoSize = true;
            this.lblFooterText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFooterText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblFooterText.Location = new System.Drawing.Point(17, 17);
            this.lblFooterText.Name = "lblFooterText";
            this.lblFooterText.Size = new System.Drawing.Size(219, 15);
            this.lblFooterText.TabIndex = 1;
            this.lblFooterText.Text = "© 2025 Phumla Kamnandi Hotels Group";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackgroundImage = global::Group38_INF2011S_Group_Project_2025.Properties.Resources.WelcomePage;
            this.pnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContent.Location = new System.Drawing.Point(153, 88);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1100, 600);
            this.pnlContent.TabIndex = 3;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1248, 739);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phumla Kamnandi Hotels - Main Menu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterText;

        // Hover effect methods
        private void BtnMakeBooking_MouseEnter(object sender, System.EventArgs e)
        {
            this.btnMakeBooking.BackColor = System.Drawing.ColorTranslator.FromHtml("#2980B9");
        }

        private void BtnMakeBooking_MouseLeave(object sender, System.EventArgs e)
        {
            this.btnMakeBooking.BackColor = System.Drawing.ColorTranslator.FromHtml("#3498DB");
        }

        private void BtnChangeBooking_MouseEnter(object sender, System.EventArgs e)
        {
            this.btnChangeBooking.BackColor = System.Drawing.ColorTranslator.FromHtml("#2980B9");
        }

        private void BtnChangeBooking_MouseLeave(object sender, System.EventArgs e)
        {
            this.btnChangeBooking.BackColor = System.Drawing.ColorTranslator.FromHtml("#3498DB");
        }

        private void BtnCancelBooking_MouseEnter(object sender, System.EventArgs e)
        {
            this.btnCancelBooking.BackColor = System.Drawing.ColorTranslator.FromHtml("#C0392B");
        }

        private void BtnCancelBooking_MouseLeave(object sender, System.EventArgs e)
        {
            this.btnCancelBooking.BackColor = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
        }

        private void BtnEnquiry_MouseEnter(object sender, System.EventArgs e)
        {
            this.btnEnquiry.BackColor = System.Drawing.ColorTranslator.FromHtml("#138D75");
        }

        private void BtnEnquiry_MouseLeave(object sender, System.EventArgs e)
        {
            this.btnEnquiry.BackColor = System.Drawing.ColorTranslator.FromHtml("#16A085");
        }

        private void BtnReports_MouseEnter(object sender, System.EventArgs e)
        {
            this.btnReports.BackColor = System.Drawing.ColorTranslator.FromHtml("#8E44AD");
        }

        private void BtnReports_MouseLeave(object sender, System.EventArgs e)
        {
            this.btnReports.BackColor = System.Drawing.ColorTranslator.FromHtml("#9B59B6");
        }

        private void BtnExit_MouseEnter(object sender, System.EventArgs e)
        {
            this.btnExit1.BackColor = System.Drawing.ColorTranslator.FromHtml("#7F8C8D");
        }

        private void BtnExit_MouseLeave(object sender, System.EventArgs e)
        {
            this.btnExit1.BackColor = System.Drawing.ColorTranslator.FromHtml("#95A5A6");
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnEnquiry;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnChangeBooking;
        private System.Windows.Forms.Button btnMakeBooking;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlMover;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit1;
    }
}