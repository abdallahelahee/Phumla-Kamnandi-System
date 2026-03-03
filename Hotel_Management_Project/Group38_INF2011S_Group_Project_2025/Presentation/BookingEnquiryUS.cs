using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Group38_INF2011S_Group_Project_2025.Business;

namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    public partial class BookingEnquiryUS : UserControl
    {
        private BookingController controller = new BookingController();
        private GuestController guestController = new GuestController();
        private Booking currentBooking;
        private List<Booking> allBookings;
        private string currentSortColumn = "";
        private bool sortAscending = true;

        public BookingEnquiryUS()
        {
            InitializeComponent();
            LoadAllBookings();
        }

        private void LoadAllBookings()
        {
            allBookings = controller.GetAllBookings();
            DisplayBookings(allBookings);
        }

        private void DisplayBookings(List<Booking> bookings)
        {
            dgvBookings.Rows.Clear();

            foreach (var booking in bookings)
            {
               
                var guest = guestController.SearchGuest(booking.GuestID);
                string guestName = guest != null ? $"{guest.FirstName} {guest.LastName}" : "Unknown";

                
                string statusDisplay = booking.Status == Booking.BookingStatus.Confirmed
                    ? "Confirmed"
                    : booking.Status.ToString();

            
                int rowIndex = dgvBookings.Rows.Add(
                    booking.ReferenceNumber,
                    guestName,
                    booking.CheckInDate.ToString("dd MMM yyyy"),
                    booking.CheckOutDate.ToString("dd MMM yyyy"),
                    booking.NumberOfNights,
                    booking.NumberOfGuests,
                    $"R{booking.TotalAmount:N2}",
                    $"R{booking.DepositAmount:N2}",
                    statusDisplay,
                    booking.BookingDate.ToString("dd MMM yyyy")
                );

             
                dgvBookings.Rows[rowIndex].Tag = booking;

     
                if (booking.Status == Booking.BookingStatus.Confirmed)
                {
                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (booking.Status == Booking.BookingStatus.Cancelled)
                {
                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dgvBookings.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else if (booking.Status == Booking.BookingStatus.Pending)
                {
                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }

            lblResultCount.Text = $"Showing {bookings.Count} of {allBookings.Count} bookings";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            string searchField = cboSearchField.SelectedItem?.ToString() ?? "All Fields";

            if (string.IsNullOrEmpty(searchTerm))
            {
                DisplayBookings(allBookings);
                return;
            }

            var filteredBookings = allBookings.Where(b =>
            {
                var guest = guestController.SearchGuest(b.GuestID);
                string guestName = guest != null ? $"{guest.FirstName} {guest.LastName}".ToLower() : "";

                switch (searchField)
                {
                    case "Reference Number":
                        return b.ReferenceNumber.ToLower().Contains(searchTerm);
                    case "Guest Name":
                        return guestName.Contains(searchTerm);
                    case "Status":
                        return b.Status.ToString().ToLower().Contains(searchTerm);
                    case "Check-In Date":
                        return b.CheckInDate.ToString("dd MMM yyyy").ToLower().Contains(searchTerm);
                    default: 
                        return b.ReferenceNumber.ToLower().Contains(searchTerm) ||
                               guestName.Contains(searchTerm) ||
                               b.Status.ToString().ToLower().Contains(searchTerm) ||
                               b.CheckInDate.ToString("dd MMM yyyy").ToLower().Contains(searchTerm) ||
                               b.CheckOutDate.ToString("dd MMM yyyy").ToLower().Contains(searchTerm);
                }
            }).ToList();

            DisplayBookings(filteredBookings);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "No guest selected, please select a guest",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

          
            var selectedRow = dgvBookings.SelectedRows[0];
            if (selectedRow.Tag is Booking selectedBooking)
            {
          
                Clipboard.SetText(selectedBooking.ReferenceNumber);

                MessageBox.Show(
                    "Reference Number copied to clipboard",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "No valid booking information found for the selected row.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        

        private void dgvBookings_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvBookings.Columns[e.ColumnIndex].Name;

            if (currentSortColumn == columnName)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                currentSortColumn = columnName;
                sortAscending = true;
            }

       
            var displayedBookings = new List<Booking>();
            foreach (DataGridViewRow row in dgvBookings.Rows)
            {
                if (row.Tag is Booking booking)
                {
                    displayedBookings.Add(booking);
                }
            }

            IEnumerable<Booking> sortedBookings = displayedBookings;

            switch (columnName)
            {
                case "colReference":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.ReferenceNumber)
                        : displayedBookings.OrderByDescending(b => b.ReferenceNumber);
                    break;
                case "colCheckIn":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.CheckInDate)
                        : displayedBookings.OrderByDescending(b => b.CheckInDate);
                    break;
                case "colCheckOut":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.CheckOutDate)
                        : displayedBookings.OrderByDescending(b => b.CheckOutDate);
                    break;
                case "colNights":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.NumberOfNights)
                        : displayedBookings.OrderByDescending(b => b.NumberOfNights);
                    break;
                case "colGuests":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.NumberOfGuests)
                        : displayedBookings.OrderByDescending(b => b.NumberOfGuests);
                    break;
                case "colTotal":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.TotalAmount)
                        : displayedBookings.OrderByDescending(b => b.TotalAmount);
                    break;
                case "colDeposit":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.DepositAmount)
                        : displayedBookings.OrderByDescending(b => b.DepositAmount);
                    break;
                case "colStatus":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.Status)
                        : displayedBookings.OrderByDescending(b => b.Status);
                    break;
                case "colBookingDate":
                    sortedBookings = sortAscending
                        ? displayedBookings.OrderBy(b => b.BookingDate)
                        : displayedBookings.OrderByDescending(b => b.BookingDate);
                    break;
            }

            DisplayBookings(sortedBookings.ToList());

         
            foreach (DataGridViewColumn col in dgvBookings.Columns)
            {
                col.HeaderCell.Style.Font = new Font(dgvBookings.Font, FontStyle.Regular);
            }
            dgvBookings.Columns[e.ColumnIndex].HeaderCell.Style.Font =
                new Font(dgvBookings.Font, FontStyle.Bold);
        }

        private void dgvBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBookings.Rows[e.RowIndex].Tag is Booking booking)
            {
                ShowBookingDetails(booking);
            }
        }

        private void ShowBookingDetails(Booking booking)
        {
            currentBooking = booking;
            var guest = guestController.SearchGuest(booking.GuestID);

            string statusInfo = booking.Status == Booking.BookingStatus.Confirmed
                ? " Confirmed (Deposit Paid)"
                : booking.Status.ToString();

            lblBookingDetails.ForeColor = ColorTranslator.FromHtml("#2C3E50");
            lblBookingDetails.Text = $"BOOKING DETAILS\n" +
                $"{'═',50}\n\n" +
                $"Reference Number:  {booking.ReferenceNumber}\n" +
                $"Guest:  {guest?.FirstName} {guest?.LastName}\n" +
                $"Status:  {statusInfo}\n\n" +
                $"CHECK-IN & STAY INFORMATION\n" +
                $"{'─',50}\n" +
                $"Check-In Date:  {booking.CheckInDate:dddd, dd MMM yyyy}\n" +
                $"Check-Out Date:  {booking.CheckOutDate:dddd, dd MMM yyyy}\n" +
                $"Number of Nights:  {booking.NumberOfNights}\n" +
                $"Number of Guests:  {booking.NumberOfGuests}\n\n" +
                $"PAYMENT INFORMATION\n" +
                $"{'─',50}\n" +
                $"Total Amount:  R{booking.TotalAmount:N2}\n" +
                $"Deposit Amount:  R{booking.DepositAmount:N2}\n" +
                $"Balance Due:  R{(booking.TotalAmount - booking.DepositAmount):N2}\n\n" +
                $"Booking Date:  {booking.BookingDate:dd MMM yyyy HH:mm}";

            btnViewLetter.Enabled = (booking.Status == Booking.BookingStatus.Confirmed);
        }

        private void btnViewLetter_Click(object sender, EventArgs e)
        {
            if (currentBooking != null)
            {
                string letter = controller.GetConfirmationLetter(currentBooking.BookingID);
                var letterForm = new Form
                {
                    Text = "Confirmation Letter - " + currentBooking.ReferenceNumber,
                    Size = new Size(650, 550),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = ColorTranslator.FromHtml("#ECF0F1")
                };

                var pnlHeader = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 50,
                    BackColor = ColorTranslator.FromHtml("#2C3E50")
                };

                var lblHeader = new Label
                {
                    Text = " Confirmation Letter",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlHeader.Controls.Add(lblHeader);

                var txtLetter = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(10, 60),
                    Size = new Size(610, 440),
                    Font = new Font("Courier New", 10),
                    Text = letter,
                    ReadOnly = true,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                letterForm.Controls.Add(pnlHeader);
                letterForm.Controls.Add(txtLetter);
                letterForm.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboSearchField.SelectedIndex = 0;
            LoadAllBookings();

            lblBookingDetails.Text = "All bookings refreshed. Double-click a booking to view details...";
            currentBooking = null;
            btnViewLetter.Enabled = false;
        }
    }
}