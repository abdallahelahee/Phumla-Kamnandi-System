namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    partial class MakeBookingUS
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
            this.components = new System.ComponentModel.Container();
            this.btnCreateBooking = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardHolder = new System.Windows.Forms.TextBox();
            this.lblCardHolder = new System.Windows.Forms.Label();
            this.grpBooking = new System.Windows.Forms.GroupBox();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.lblNights = new System.Windows.Forms.Label();
            this.numGuests = new System.Windows.Forms.NumericUpDown();
            this.lblGuests = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.grpGuest = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblOr = new System.Windows.Forms.Label();
            this.cboGuest = new System.Windows.Forms.ComboBox();
            this.lblSelectGuest = new System.Windows.Forms.Label();
            this.epPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCardNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.epEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlMain.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.grpBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGuests)).BeginInit();
            this.grpGuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCardNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateBooking
            // 
            this.btnCreateBooking.BackColor = System.Drawing.Color.Gray;
            this.btnCreateBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateBooking.FlatAppearance.BorderSize = 0;
            this.btnCreateBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBooking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateBooking.ForeColor = System.Drawing.Color.White;
            this.btnCreateBooking.Location = new System.Drawing.Point(735, 507);
            this.btnCreateBooking.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateBooking.Name = "btnCreateBooking";
            this.btnCreateBooking.Size = new System.Drawing.Size(142, 33);
            this.btnCreateBooking.TabIndex = 5;
            this.btnCreateBooking.Text = "✅ Create Booking";
            this.btnCreateBooking.UseVisualStyleBackColor = false;
            this.btnCreateBooking.Click += new System.EventHandler(this.btnCreateBooking_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.grpPayment);
            this.pnlMain.Controls.Add(this.grpBooking);
            this.pnlMain.Controls.Add(this.grpGuest);
            this.pnlMain.Location = new System.Drawing.Point(203, 23);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(674, 480);
            this.pnlMain.TabIndex = 4;
            // 
            // grpPayment
            // 
            this.grpPayment.BackColor = System.Drawing.Color.White;
            this.grpPayment.Controls.Add(this.lblDeposit);
            this.grpPayment.Controls.Add(this.lblTotalAmount);
            this.grpPayment.Controls.Add(this.txtCardNumber);
            this.grpPayment.Controls.Add(this.lblCardNumber);
            this.grpPayment.Controls.Add(this.txtCardHolder);
            this.grpPayment.Controls.Add(this.lblCardHolder);
            this.grpPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpPayment.Location = new System.Drawing.Point(0, 374);
            this.grpPayment.Margin = new System.Windows.Forms.Padding(2);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Padding = new System.Windows.Forms.Padding(2);
            this.grpPayment.Size = new System.Drawing.Size(672, 78);
            this.grpPayment.TabIndex = 2;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment Details";
            // 
            // lblDeposit
            // 
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDeposit.Location = new System.Drawing.Point(300, 51);
            this.lblDeposit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(250, 18);
            this.lblDeposit.TabIndex = 5;
            this.lblDeposit.Text = "Deposit Required: R 0.00";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(14, 51);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(250, 18);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "Total Amount: R 0.00";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardNumber.Location = new System.Drawing.Point(481, 21);
            this.txtCardNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtCardNumber.MaxLength = 16;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(152, 25);
            this.txtCardNumber.TabIndex = 3;
            this.txtCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardNumber_KeyPress);
            this.txtCardNumber.Validated += new System.EventHandler(this.txtCardNumber_Validated);
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardNumber.Location = new System.Drawing.Point(355, 23);
            this.lblCardNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(122, 15);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "Card Number:*";
            // 
            // txtCardHolder
            // 
            this.txtCardHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardHolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardHolder.Location = new System.Drawing.Point(142, 21);
            this.txtCardHolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtCardHolder.Name = "txtCardHolder";
            this.txtCardHolder.Size = new System.Drawing.Size(122, 25);
            this.txtCardHolder.TabIndex = 1;
            this.txtCardHolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardHolder_KeyPress);
            // 
            // lblCardHolder
            // 
            this.lblCardHolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardHolder.Location = new System.Drawing.Point(14, 23);
            this.lblCardHolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCardHolder.Name = "lblCardHolder";
            this.lblCardHolder.Size = new System.Drawing.Size(122, 15);
            this.lblCardHolder.TabIndex = 0;
            this.lblCardHolder.Text = "Card Holder Name:*";
            // 
            // grpBooking
            // 
            this.grpBooking.BackColor = System.Drawing.Color.White;
            this.grpBooking.Controls.Add(this.cboRoom);
            this.grpBooking.Controls.Add(this.lblRoom);
            this.grpBooking.Controls.Add(this.btnCheckAvailability);
            this.grpBooking.Controls.Add(this.lblNights);
            this.grpBooking.Controls.Add(this.numGuests);
            this.grpBooking.Controls.Add(this.lblGuests);
            this.grpBooking.Controls.Add(this.dtpCheckOut);
            this.grpBooking.Controls.Add(this.lblCheckOut);
            this.grpBooking.Controls.Add(this.dtpCheckIn);
            this.grpBooking.Controls.Add(this.lblCheckIn);
            this.grpBooking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpBooking.Location = new System.Drawing.Point(2, 2);
            this.grpBooking.Margin = new System.Windows.Forms.Padding(2);
            this.grpBooking.Name = "grpBooking";
            this.grpBooking.Padding = new System.Windows.Forms.Padding(2);
            this.grpBooking.Size = new System.Drawing.Size(670, 125);
            this.grpBooking.TabIndex = 1;
            this.grpBooking.TabStop = false;
            this.grpBooking.Text = "Booking Details";
            // 
            // cboRoom
            // 
            this.cboRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoom.DropDownWidth = 138;
            this.cboRoom.Enabled = false;
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.ItemHeight = 20;
            this.cboRoom.Location = new System.Drawing.Point(255, 86);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(138, 28);
            this.cboRoom.TabIndex = 14;
            this.cboRoom.SelectedIndexChanged += new System.EventHandler(this.cboRoom_SelectedIndexChanged_2);
            // 
            // lblRoom
            // 
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoom.Location = new System.Drawing.Point(163, 87);
            this.lblRoom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(87, 18);
            this.lblRoom.TabIndex = 8;
            this.lblRoom.Text = "Select Room:";
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCheckAvailability.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckAvailability.FlatAppearance.BorderSize = 0;
            this.btnCheckAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAvailability.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCheckAvailability.ForeColor = System.Drawing.Color.White;
            this.btnCheckAvailability.Location = new System.Drawing.Point(17, 87);
            this.btnCheckAvailability.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(142, 27);
            this.btnCheckAvailability.TabIndex = 7;
            this.btnCheckAvailability.Text = "🔍 Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = false;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // lblNights
            // 
            this.lblNights.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.lblNights.Location = new System.Drawing.Point(228, 52);
            this.lblNights.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(165, 18);
            this.lblNights.TabIndex = 6;
            this.lblNights.Text = "Number of Nights: 1";
            // 
            // numGuests
            // 
            this.numGuests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numGuests.Location = new System.Drawing.Point(142, 50);
            this.numGuests.Margin = new System.Windows.Forms.Padding(2);
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
            this.numGuests.Size = new System.Drawing.Size(72, 25);
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
            this.lblGuests.Location = new System.Drawing.Point(4, 52);
            this.lblGuests.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(134, 20);
            this.lblGuests.TabIndex = 4;
            this.lblGuests.Text = "Number of Guests:*";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCheckOut.Location = new System.Drawing.Point(438, 21);
            this.dtpCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(228, 25);
            this.dtpCheckOut.TabIndex = 3;
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckOut.Location = new System.Drawing.Point(361, 21);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(77, 15);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "Check-Out Date:*";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCheckIn.Location = new System.Drawing.Point(119, 21);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(238, 25);
            this.dtpCheckIn.TabIndex = 1;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckIn.Location = new System.Drawing.Point(14, 22);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(122, 15);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Check-In Date:*";
            // 
            // grpGuest
            // 
            this.grpGuest.BackColor = System.Drawing.Color.White;
            this.grpGuest.Controls.Add(this.txtPhone);
            this.grpGuest.Controls.Add(this.txtAddress);
            this.grpGuest.Controls.Add(this.lblAddress);
            this.grpGuest.Controls.Add(this.lblPhone);
            this.grpGuest.Controls.Add(this.txtEmail);
            this.grpGuest.Controls.Add(this.lblEmail);
            this.grpGuest.Controls.Add(this.txtLastName);
            this.grpGuest.Controls.Add(this.lblLastName);
            this.grpGuest.Controls.Add(this.txtFirstName);
            this.grpGuest.Controls.Add(this.lblFirstName);
            this.grpGuest.Controls.Add(this.lblOr);
            this.grpGuest.Controls.Add(this.cboGuest);
            this.grpGuest.Controls.Add(this.lblSelectGuest);
            this.grpGuest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpGuest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpGuest.Location = new System.Drawing.Point(2, 163);
            this.grpGuest.Margin = new System.Windows.Forms.Padding(2);
            this.grpGuest.Name = "grpGuest";
            this.grpGuest.Padding = new System.Windows.Forms.Padding(2);
            this.grpGuest.Size = new System.Drawing.Size(670, 178);
            this.grpGuest.TabIndex = 0;
            this.grpGuest.TabStop = false;
            this.grpGuest.Text = "Guest Information";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(479, 106);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(122, 25);
            this.txtPhone.TabIndex = 13;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(144, 142);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(457, 25);
            this.txtAddress.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(13, 144);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(122, 15);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Full Address:*";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.Location = new System.Drawing.Point(352, 109);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(122, 15);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Phone Number:*";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(142, 104);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(122, 25);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(13, 106);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(122, 15);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email Address:*";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.Location = new System.Drawing.Point(479, 68);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(122, 25);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastName_KeyPress);
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLastName.Location = new System.Drawing.Point(353, 70);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(122, 15);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "Last Name:*";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(142, 68);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(122, 25);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyPress);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFirstName.Location = new System.Drawing.Point(14, 70);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(122, 15);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name:*";
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblOr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblOr.Location = new System.Drawing.Point(4, 45);
            this.lblOr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(183, 15);
            this.lblOr.TabIndex = 2;
            this.lblOr.Text = "— OR Enter New Guest Details —";
            // 
            // cboGuest
            // 
            this.cboGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGuest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGuest.FormattingEnabled = true;
            this.cboGuest.Location = new System.Drawing.Point(148, 18);
            this.cboGuest.Margin = new System.Windows.Forms.Padding(2);
            this.cboGuest.Name = "cboGuest";
            this.cboGuest.Size = new System.Drawing.Size(453, 25);
            this.cboGuest.TabIndex = 1;
            this.cboGuest.SelectedIndexChanged += new System.EventHandler(this.cboGuest_SelectedIndexChanged_1);
            // 
            // lblSelectGuest
            // 
            this.lblSelectGuest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectGuest.Location = new System.Drawing.Point(14, 22);
            this.lblSelectGuest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectGuest.Name = "lblSelectGuest";
            this.lblSelectGuest.Size = new System.Drawing.Size(122, 21);
            this.lblSelectGuest.TabIndex = 0;
            this.lblSelectGuest.Text = "Select Existing Guest:";
            // 
            // epPhone
            // 
            this.epPhone.ContainerControl = this;
            // 
            // epCardNumber
            // 
            this.epCardNumber.ContainerControl = this;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(201, 507);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 33);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Reset Fields";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // epEmail
            // 
            this.epEmail.ContainerControl = this;
            // 
            // MakeBookingUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateBooking);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MakeBookingUS";
            this.Size = new System.Drawing.Size(1100, 600);
            this.pnlMain.ResumeLayout(false);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.grpBooking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGuests)).EndInit();
            this.grpGuest.ResumeLayout(false);
            this.grpGuest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCardNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateBooking;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtCardHolder;
        private System.Windows.Forms.Label lblCardHolder;
        private System.Windows.Forms.GroupBox grpBooking;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.NumericUpDown numGuests;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.GroupBox grpGuest;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.ComboBox cboGuest;
        private System.Windows.Forms.Label lblSelectGuest;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.ErrorProvider epPhone;
        private System.Windows.Forms.ErrorProvider epCardNumber;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ErrorProvider epEmail;
    }
}
