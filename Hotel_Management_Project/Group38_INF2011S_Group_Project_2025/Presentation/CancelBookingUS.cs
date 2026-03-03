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

namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    public partial class CancelBookingUS : UserControl
    {
        private BookingController controller = new BookingController();
        private Booking currentBooking;

        public CancelBookingUS()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string refNum = txtReferenceNumber.Text.Trim();
            if (string.IsNullOrEmpty(refNum))
            {
                MessageBox.Show("Please enter a reference number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentBooking = controller.FindBooking(refNum);
            if (currentBooking == null)
            {
                MessageBox.Show("Booking not found.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblBookingDetails.Text = " Booking not found.";
                lblBookingDetails.ForeColor = ColorTranslator.FromHtml("#E74C3C");
                btnCancel.Enabled = false;
               
                return;
            }

            if (currentBooking.Status == Booking.BookingStatus.Cancelled)
            {
                lblBookingDetails.Text = " This booking has already been cancelled.";
                lblBookingDetails.ForeColor = ColorTranslator.FromHtml("#E67E22");
                btnCancel.Enabled = false;
             
                return;
            }

            lblBookingDetails.ForeColor = ColorTranslator.FromHtml("#2C3E50");
            lblBookingDetails.Text = $"BOOKING TO BE CANCELLED\n" +
                $"{'═',50}\n\n" +
                $"Reference:  {currentBooking.ReferenceNumber}\n" +
                $"Status:  {currentBooking.Status}\n\n" +
                $"Check-In:  {currentBooking.CheckInDate:dd MMM yyyy}\n" +
                $"Check-Out:  {currentBooking.CheckOutDate:dd MMM yyyy}\n" +
                $"Guests:  {currentBooking.NumberOfGuests}\n\n" +
                $"Total Amount:  R{currentBooking.TotalAmount:N2}\n" +
                $"Deposit Paid:  R{currentBooking.DepositAmount:N2}";

            btnCancel.Enabled = true;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to cancel this booking?\n\n" +
                " Deposit may be retained as per cancellation policy.",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool success = controller.CancelBooking(currentBooking.ReferenceNumber);
                if (success)
                {
                    MessageBox.Show(
                        " The booking has been cancelled successfully.\n\n" +
                        " A cancellation email has been sent to the guest (if an internet connection was available).",
                        "Booking Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    reset_Fields();
                }
                else
                {
                    MessageBox.Show(
                        " An error occurred while cancelling the booking.\nPlease try again or contact support.",
                        "Cancellation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
        }

        private void reset_Fields()
        {
            txtReferenceNumber.Clear();
            lblBookingDetails.Text = "Enter a reference number to search for a booking.";
            lblBookingDetails.ForeColor = ColorTranslator.FromHtml("#7F8C8D");
            btnCancel.Enabled = false;
            currentBooking = null;
        }

        private void CancelBookingUS_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset_Fields();
        }
    }
}
