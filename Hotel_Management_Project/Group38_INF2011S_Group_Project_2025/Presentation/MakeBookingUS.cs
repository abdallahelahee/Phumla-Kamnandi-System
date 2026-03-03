using Group38_INF2011S_Group_Project_2025.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    public partial class MakeBookingUS : UserControl
    {
        private BookingController controller = new BookingController();
        private Boolean CheckedAvailability = false;

        public MakeBookingUS()
        {
            InitializeComponent();
            LoadExistingGuests();

            
            txtFirstName.TextChanged += OnControlValueChanged;
            txtLastName.TextChanged += OnControlValueChanged;
            txtEmail.TextChanged += OnControlValueChanged;
            txtPhone.TextChanged += OnControlValueChanged;
            txtAddress.TextChanged += OnControlValueChanged;
            txtCardHolder.TextChanged += OnControlValueChanged;
            txtCardNumber.TextChanged += OnControlValueChanged;
            numGuests.ValueChanged += OnControlValueChanged;

        
            cboRoom.SelectedIndexChanged += OnControlValueChanged;

    
            ValidateForm();
        }
        
        private void LoadExistingGuests()
        {
            cboGuest.Items.Clear();
            cboGuest.Items.Add("-- Select Existing Guest --");
            foreach (var guest in controller.GetAllGuests())
            {
                cboGuest.Items.Add(guest);
            }
            cboGuest.DisplayMember = "FullName";
            cboGuest.SelectedIndex = 0;
        }
        private void DateChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value > dtpCheckIn.Value)
            {
                int nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                lblNights.Text = $"Number of Nights: {nights}";
                cboRoom.Items.Clear();
                cboRoom.Enabled = false;


            }
        }

        #region input and button events
        private void CboGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGuest.SelectedItem is Guest guest)
            {
                txtFirstName.Text = guest.FirstName;
                txtLastName.Text = guest.LastName;
                txtEmail.Text = guest.Email;
                txtPhone.Text = guest.Phone;
                txtAddress.Text = guest.Address;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            reset_Fields();
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {   
            
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var availableRooms = controller.CheckAvailability(dtpCheckIn.Value, dtpCheckOut.Value);
            cboRoom.Items.Clear();

            if (availableRooms.Count == 0)
            {
                DateTime suggestedCheckIn = dtpCheckIn.Value.AddDays(1);
                DateTime suggestedCheckOut = dtpCheckOut.Value.AddDays(1);
                int maxLookAheadDays = 30;
                bool found = false;

                for (int i = 0; i < maxLookAheadDays; i++)
                {
                    var rooms = controller.CheckAvailability(suggestedCheckIn, suggestedCheckOut);
                    if (rooms.Count > 0)
                    {
                        found = true;
                        break;
                    }
                    suggestedCheckIn = suggestedCheckIn.AddDays(1);
                    suggestedCheckOut = suggestedCheckOut.AddDays(1);
                }

                if (found)
                {
                    MessageBox.Show(
                        $"No rooms available for selected dates.\n\n" +
                        $"Next available dates: {suggestedCheckIn:dd MMM yyyy} to {suggestedCheckOut:dd MMM yyyy}",
                        "No Availability",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "No rooms available for the selected dates or in the next 30 days.",
                        "No Availability",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                cboRoom.Enabled = false;
                return;
            }


            foreach (var room in availableRooms)
            {
                cboRoom.Items.Add(room);
            }
            cboRoom.DisplayMember = "RoomNumber";
            cboRoom.SelectedIndex = 0;
            cboRoom.Enabled = true;
            cboRoom.BackColor = Color.White;

        }

        
        private void CboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoom.SelectedItem is Room room)
            {
                int nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                decimal pricePerNight = Booking.GetSeasonalRate(dtpCheckIn.Value);
                decimal total = pricePerNight * nights;
                decimal deposit = total * 0.10m;

                lblTotalAmount.Text = $"Total Amount: R {total:N2}";
                lblDeposit.Text = $"Deposit Required: R {deposit:N2}";
                CheckedAvailability = true;
            }
        }
        

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
               string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) ||
               string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all guest details.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPhone.MaskCompleted == false)
            {
                MessageBox.Show("Complete Phone Number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCardHolder.Text) || string.IsNullOrWhiteSpace(txtCardNumber.Text))
            {
                MessageBox.Show("Please fill in payment details.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCardNumber.TextLength != 16)
            {
                MessageBox.Show("Please fill in payment details.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            if (cboRoom.SelectedItem == null)
            {
                MessageBox.Show("Please select a room.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var guest = controller.FindOrCreateGuest(
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim()
                );

                var room = (Room)cboRoom.SelectedItem;

                var booking = controller.CreateBooking(
                    guest.GuestID,
                    room.RoomID,
                    dtpCheckIn.Value,
                    dtpCheckOut.Value,
                    (int)numGuests.Value,
                    txtCardNumber.Text.Trim(),
                    txtCardHolder.Text.Trim()
                );

                string confirmLetter = controller.GetConfirmationLetter(booking.BookingID);

                MessageBox.Show(
                    $"Booking created successfully!\n\n" +
                    $"Reference Number: {booking.ReferenceNumber}\n\n" +
                    "📧 A confirmation email has been sent to the guest (if an internet connection is available).",
                    "Booking Confirmed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                var letterForm = new Form
                {
                    Text = "Confirmation Letter",
                    Size = new Size(650, 550),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = ColorTranslator.FromHtml("#ECF0F1")
                };
                var txtLetter = new System.Windows.Forms.TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Dock = DockStyle.Fill,
                    Font = new Font("Courier New", 10),
                    Text = confirmLetter,
                    ReadOnly = true,
                    BackColor = Color.White,
                    Margin = new Padding(10)
                };
                letterForm.Controls.Add(txtLetter);
                letterForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset_Fields();

        }

        private void cboGuest_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboGuest.SelectedItem is Guest guest)
            {
                txtFirstName.Text = guest.FirstName;
                txtLastName.Text = guest.LastName;
                txtEmail.Text = guest.Email;
                txtPhone.Text = guest.Phone;
                txtPhone.Text = guest.Phone;
                txtAddress.Text = guest.Address;
            }

            if (cboGuest.SelectedIndex == 0)
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtPhone.Text = ""; 
                txtAddress.Text = "";
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value > dtpCheckIn.Value)
            {
                int nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                lblNights.Text = $"Number of Nights: {nights}";
                lblTotalAmount.Text = "Total Amount: R 0.00";
                lblDeposit.Text = "Deposit Required: R 0.00";
                cboRoom.Items.Clear();
                cboRoom.Enabled = false;
                cboRoom.BackColor = Color.Gray;
                btnCreateBooking.BackColor = Color.Gray;
            }
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value > dtpCheckIn.Value)
            {
                int nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                lblNights.Text = $"Number of Nights: {nights}";
                lblTotalAmount.Text = "Total Amount: R 0.00";
                lblDeposit.Text = "Deposit Required: R 0.00";
                cboRoom.Items.Clear();
                cboRoom.Enabled = false;
                cboRoom.BackColor = Color.Gray; 
                btnCreateBooking.BackColor = Color.Gray;
            }
        }

       

        private void cboRoom_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (cboRoom.SelectedItem is Room room)
            {
              

                int nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                decimal pricePerNight = Booking.GetSeasonalRate(dtpCheckIn.Value);
                decimal total = pricePerNight * nights;
                decimal deposit = total * 0.10m;

                lblTotalAmount.Text = $"Total Amount: R {total:N2}";
                lblDeposit.Text = $"Deposit Required: R {deposit:N2}";
                CheckedAvailability = true;


            }

        }

        

        private void reset_Fields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCardHolder.Text = "";
            txtCardNumber.Text = "";
            cboGuest.SelectedIndex = 0;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            numGuests.Value = 1;
            cboRoom.Items.Clear();
            cboRoom.Enabled = false;
            cboRoom.BackColor = Color.Gray;
            lblNights.Text = "Number of Nights: 0";
            lblTotalAmount.Text = "Total Amount: R 0.00";
            lblDeposit.Text = "Deposit Required: R 0.00";
            epEmail.Clear();
            epPhone.Clear();
            epCardNumber.Clear();

        }
        #endregion
        #region Validation
     

        private void OnControlValueChanged(object sender, EventArgs e)
        {
    
            ValidateForm();
        }

        private void ValidateForm()
        {
            
            bool isFormValid = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCardHolder.Text) ||
                string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
                txtPhone.MaskCompleted == false ||
                txtCardNumber.TextLength != 16 ||
                CheckedAvailability == false) 
            {
                isFormValid = false;
            }

       
            if (isFormValid)
            {
                btnCreateBooking.BackColor = System.Drawing.Color.FromArgb(39, 174, 96); 
            }
            else
            {
        
                btnCreateBooking.BackColor = Color.Gray;
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCardHolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
      
            if (!txtPhone.MaskCompleted && txtPhone.Text!="")
            {
         
                epPhone.SetError(txtPhone, "Please enter a complete phone number.");
                
            }
            else
            {
       
                epPhone.SetError(txtPhone, "");
            }
        }

        private void txtCardNumber_Validated(object sender, EventArgs e)
        {
            if (txtCardNumber.TextLength != 16 && txtCardNumber.Text!="")
            {
                epCardNumber.SetError(txtCardNumber, "Card Number must be exactly 16 digits.");
              
            }
            else
            {
                epCardNumber.SetError(txtCardNumber, "");
            }
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;

            if (!IsValidEmail(email) && !string.IsNullOrWhiteSpace(email))
            {
    
                epEmail.SetError(txtEmail, "Please enter a valid email address.");
            }
            else
            {
           
                epEmail.SetError(txtEmail, "");
            }
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}
