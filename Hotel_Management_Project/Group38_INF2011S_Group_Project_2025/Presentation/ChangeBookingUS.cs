using Group38_INF2011S_Group_Project_2025.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    
    public partial class ChangeBookingUS : UserControl
    {
        private string refNum;
        private BookingController controller = new BookingController();
        private Booking currentBooking;

        public ChangeBookingUS()
        {
            InitializeComponent();


            dtpCheckIn.ValueChanged += OnControlValueChanged;
            dtpCheckOut.ValueChanged += OnControlValueChanged;
            numGuests.ValueChanged += OnControlValueChanged;
         
            
        }

        #region  buton events
        private void btnSearch_Click(object sender, EventArgs e)
        {

            refNum = txtReferenceNumber.Text.Trim();
            if (string.IsNullOrEmpty(refNum))
            {   
                grpNew.Enabled = false;
                MessageBox.Show("Please enter a reference number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reset_Fields();
                
                return;
            }

           

            currentBooking = controller.FindBooking(refNum);
            if (currentBooking == null)
            {
                grpNew.Enabled = false;
                MessageBox.Show("Booking not found.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblCurrentDetails.Text = "Booking not found.";
                return;
            }

            if (currentBooking.Status == Booking.BookingStatus.Cancelled)
            {
                MessageBox.Show("This booking has been cancelled and cannot be changed.",
                    "Cancelled Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grpNew.Enabled = true;
            ValidateForm(refNum);

            lblCurrentDetails.Text = $"CURRENT BOOKING\n{'═',50}\n\n" +
                $"Reference:  {currentBooking.ReferenceNumber}\n" +
                $"Status:  {currentBooking.Status}\n\n" +
                $"Check-In:  {currentBooking.CheckInDate:dd MMM yyyy}\n" +
                $"Check-Out:  {currentBooking.CheckOutDate:dd MMM yyyy}\n" +
                $"Guests:  {currentBooking.NumberOfGuests}";

            dtpCheckIn.Value = currentBooking.CheckInDate;
            dtpCheckOut.Value = currentBooking.CheckOutDate;
            numGuests.Value = currentBooking.NumberOfGuests;

            grpNew.Enabled = true;
            btnUpdate.Enabled = true;
            CalculateNewTotal();
        }


        private void CalculateNewTotal()
        {
            if (currentBooking != null && dtpCheckOut.Value > dtpCheckIn.Value)
            {
                int nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                decimal pricePerNight = Booking.GetSeasonalRate(dtpCheckIn.Value);
                decimal total = pricePerNight * nights;
                lblNewTotal.Text = $"New Total: R {total:N2}";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.BackColor == Color.Gray)
            {
                MessageBox.Show("No changes have been made");
                return;
            }
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.",
                    "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                var updatedBooking = controller.UpdateBooking(
                    currentBooking.ReferenceNumber,
                    dtpCheckIn.Value,
                    dtpCheckOut.Value,
                    (int)numGuests.Value
                );

                MessageBox.Show($"Booking updated successfully!\n\n" +
                    $"New Total: R{updatedBooking.TotalAmount:N2}\n" +
                    $"New Deposit: R{updatedBooking.DepositAmount:N2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset_Fields();
        }

        #endregion

        #region validation methods
        private void OnControlValueChanged(object sender, EventArgs e)
        {
        
            DateTime checkin = dtpCheckIn.Value;
            DateTime checkout = dtpCheckOut.Value;  
            int guests = (int)numGuests.Value;

            
            CalculateNewTotal();
            ValidateForm(refNum);
            
        }

        private void ValidateForm(String refNum)
        {
            DateTime checkin = dtpCheckIn.Value;
            DateTime checkout = dtpCheckOut.Value;
            int guests = (int)numGuests.Value;
            if (string.IsNullOrEmpty(refNum) || refNum.Length!=15){
                return;
            }
            else
            {
                currentBooking = controller.FindBooking(refNum);

                if (currentBooking.CheckInDate != checkin ||
                    currentBooking.CheckOutDate != checkout ||
                    currentBooking.NumberOfGuests != guests)
                {
                    btnUpdate.BackColor = System.Drawing.Color.FromArgb(39, 174, 96); 
                    return;
                }
                btnUpdate.BackColor = Color.Gray; 
            }


                
            
        }

        private void reset_Fields()
        {
            txtReferenceNumber.Clear();
            lblCurrentDetails.Text = "❌ No booking loaded.";
            grpNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            numGuests.Value = 1;
            lblNewTotal.Text = "New Total: R 0.00";
        }

        #endregion

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
           
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset_Fields();
        }
    }
}
