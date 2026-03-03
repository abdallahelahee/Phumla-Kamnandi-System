using Group38_INF2011S_Group_Project_2025.Business;
using Group38_INF2011S_Group_Project_2025.Database;
using ScottPlot;
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
    public partial class ReportsUS : UserControl
    {

        private BookingController controller = new BookingController();
        public ReportsUS()
        {
            InitializeComponent();
            
        }

        private void btnGenerateOccupancy_Click(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Invalid Dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var occupancyData = controller.GetOccupancyReport(dtpStartDate.Value, dtpEndDate.Value);

            dgvReport.Columns.Clear();
            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("RoomsOccupied", "Rooms Occupied");
            dgvReport.Columns.Add("TotalRooms", "Total Rooms");
            dgvReport.Columns.Add("OccupancyRate", "Occupancy Rate");
            dgvReport.Columns.Add("Status", "Status");


            dgvReport.Rows.Clear();

            int totalRooms = 5;

            List<KeyValuePair<DateTime, int>> sortedOccupancy = new List<KeyValuePair<DateTime, int>>();
            foreach (var entry in occupancyData)
            {
                sortedOccupancy.Add(entry);
            }

            // Bubble sort
            for (int i = 0; i < sortedOccupancy.Count - 1; i++)
            {
                for (int j = 0; j < sortedOccupancy.Count - i - 1; j++)
                {
                    if (sortedOccupancy[j].Key > sortedOccupancy[j + 1].Key)
                    {
                        var temp = sortedOccupancy[j];
                        sortedOccupancy[j] = sortedOccupancy[j + 1];
                        sortedOccupancy[j + 1] = temp;
                    }
                }
            }

            foreach (var entry in sortedOccupancy)
            {
                int occupied = entry.Value;
                double rate = (occupied / (double)totalRooms) * 100;
                string status = rate == 100 ? "FULL" : rate >= 80 ? "High" : rate >= 50 ? "Medium" : "Low";

                dgvReport.Rows.Add(
                    entry.Key.ToString("dd MMM yyyy"),
                    occupied,
                    totalRooms,
                    $"{rate:F1}%",
                    status
                );
            }

            // Color coding
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();
                if (status == "FULL")
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E74C3C");
                else if (status == "High")
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F39C12");
                else if (status == "Medium")
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F1C40F");
                else
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2ECC71");

                row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            }
            
            UpdateOccupancyChart(sortedOccupancy, totalRooms);


        }

        private void btnGenerateRevenue_Click(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Invalid Dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bookingDA = new BookingDA();
            var bookings = bookingDA.GetBookingsByDateRange(dtpStartDate.Value, dtpEndDate.Value);

            dgvReport.Columns.Clear();
            dgvReport.Columns.Add("RefNumber", "Reference");
            dgvReport.Columns.Add("CheckIn", "Check-In");
            dgvReport.Columns.Add("CheckOut", "Check-Out");
            dgvReport.Columns.Add("Nights", "Nights");
            dgvReport.Columns.Add("Status", "Status");
            dgvReport.Columns.Add("TotalAmount", "Total Amount");
            dgvReport.Columns.Add("Deposit", "Deposit");
            dgvReport.Columns.Add("Balance", "Balance");


            dgvReport.Columns["CheckIn"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvReport.Columns["CheckOut"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvReport.Columns["Status"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvReport.Columns["Nights"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvReport.Rows.Clear();

            decimal totalRevenue = 0;
            decimal totalDeposits = 0;

            List<Booking> sortedBookings = new List<Booking>();
            foreach (var booking in bookings)
            {
                sortedBookings.Add(booking);
            }

            // Bubble sort
            for (int i = 0; i < sortedBookings.Count - 1; i++)
            {
                for (int j = 0; j < sortedBookings.Count - i - 1; j++)
                {
                    if (sortedBookings[j].CheckInDate > sortedBookings[j + 1].CheckInDate)
                    {
                        var temp = sortedBookings[j];
                        sortedBookings[j] = sortedBookings[j + 1];
                        sortedBookings[j + 1] = temp;
                    }
                }
                UpdateFinancialChart(sortedBookings, dtpStartDate.Value, dtpEndDate.Value);
            }

            foreach (var booking in sortedBookings)
            {
                dgvReport.Rows.Add(
                    booking.ReferenceNumber,
                    booking.CheckInDate.ToString("dd MMM"),
                    booking.CheckOutDate.ToString("dd MMM"),
                    booking.NumberOfNights,
                    booking.Status,
                    $"R{booking.TotalAmount:N2}",
                    $"R{booking.DepositAmount:N2}",
                    $"R{(booking.TotalAmount - booking.DepositAmount):N2}"
                );

                if (booking.Status != Booking.BookingStatus.Cancelled)
                {
                    totalRevenue += booking.TotalAmount;
                    totalDeposits += booking.DepositAmount;
                }
            }

            int summaryRow = dgvReport.Rows.Add(
                "TOTAL",
                "",
                "",
                "",
                $"{bookings.Count} bookings",
                $"R{totalRevenue:N2}",
                $"R{totalDeposits:N2}",
                $"R{(totalRevenue - totalDeposits):N2}"
            );

            dgvReport.Rows[summaryRow].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3498DB");
            dgvReport.Rows[summaryRow].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvReport.Rows[summaryRow].DefaultCellStyle.Font = new Font(dgvReport.Font, System.Drawing.FontStyle.Bold);
            dgvReport.Rows[summaryRow].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#3498DB");

            UpdateFinancialChart(sortedBookings, dtpStartDate.Value, dtpEndDate.Value);
        }






        private void UpdateFinancialChart(List<Booking> bookings, DateTime reportStartDate, DateTime reportEndDate)
        {
            formsPlot1.Plot.Clear();

            var dailyRevenue = new Dictionary<DateTime, decimal>();
            for (DateTime day = reportStartDate.Date; day <= reportEndDate.Date; day = day.AddDays(1))
            {
                dailyRevenue.Add(day, 0m);
            }

            if (bookings != null)
            {
                foreach (var booking in bookings)
                {
                    if (booking.Status != Booking.BookingStatus.Cancelled && booking.NumberOfNights > 0)
                    {
                        decimal dailyRate = booking.TotalAmount / booking.NumberOfNights;
                        for (DateTime day = booking.CheckInDate; day < booking.CheckOutDate; day = day.AddDays(1))
                        {
                            if (dailyRevenue.ContainsKey(day.Date))
                            {
                                dailyRevenue[day.Date] += dailyRate;
                            }
                        }
                    }
                }
            }

         
            var sortedDailyRevenue = dailyRevenue.OrderBy(kvp => kvp.Key).ToList();
            double[] positions = Enumerable.Range(0, sortedDailyRevenue.Count).Select(i => (double)i).ToArray();
            double[] revenues = sortedDailyRevenue.Select(kvp => (double)kvp.Value).ToArray();

            var bars = formsPlot1.Plot.Add.Bars(positions, revenues);
            bars.LegendText = "Daily Revenue";
            bars.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(120, 52, 152, 219));

            formsPlot1.Plot.Title("Daily Revenue Report");
            formsPlot1.Plot.Axes.Left.Label.Text = "Total Revenue (R)";
            formsPlot1.Plot.Axes.Bottom.Label.Text = "Date";

            var dateTicks = sortedDailyRevenue
                .Select((kvp, index) => new ScottPlot.Tick(index, kvp.Key.ToString("dd MMM")))
                .ToArray();
            formsPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(dateTicks);
            formsPlot1.Plot.Axes.Bottom.MajorTickStyle.Length = 0;

            formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot.Alignment.MiddleLeft;

       
            formsPlot1.Plot.Axes.Bottom.Min = -0.5;
            formsPlot1.Plot.Axes.Bottom.Max = positions.Length - 0.5;

            formsPlot1.Plot.Axes.Margins(0, 0);

            
            formsPlot1.Plot.Axes.Left.Min = 0;

    
            double maxRevenue = revenues.Any() ? revenues.Max() : 1000; 
            double yMax = Math.Ceiling(maxRevenue / 1000) * 1000;
            if (yMax == 0) yMax = 1000; 

     
            List<ScottPlot.Tick> yTicks = new List<ScottPlot.Tick>();
            for (double i = 0; i <= yMax; i += 1000)
            {
                yTicks.Add(new ScottPlot.Tick(i, $"R{i / 1000:N0}K"));
            }
            formsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(yTicks.ToArray());

   
            formsPlot1.Plot.FigureBackground.Color = ScottPlot.Colors.White;
            formsPlot1.Plot.DataBackground.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(50, 240, 240, 240));

            formsPlot1.Refresh();
        }



        private void UpdateOccupancyChart(List<KeyValuePair<DateTime, int>> occupancyData, int totalRooms)
        {
            formsPlot1.Plot.Clear();

            if (occupancyData.Count > 0)
            {
                
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;

                var occupancyDict = occupancyData.ToDictionary(kvp => kvp.Key.Date, kvp => kvp.Value);

           
                var allDates = new List<KeyValuePair<DateTime, int>>();
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    int roomsOccupied = occupancyDict.ContainsKey(date) ? occupancyDict[date] : 0;
                    allDates.Add(new KeyValuePair<DateTime, int>(date, roomsOccupied));
                }

                double[] positions = Enumerable.Range(0, allDates.Count).Select(i => (double)i).ToArray();
                double[] occupancyPercentages = allDates.Select(kvp => (kvp.Value / (double)totalRooms) * 100).ToArray();

                var bars = formsPlot1.Plot.Add.Bars(positions, occupancyPercentages);
                bars.LegendText = "Occupancy Rate";
                bars.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(120, 52, 152, 219));


                formsPlot1.Plot.Title("Daily Occupancy Report");
                formsPlot1.Plot.Axes.Left.Label.Text = "Occupancy Rate (%)";
                formsPlot1.Plot.Axes.Bottom.Label.Text = "Date";

              
                formsPlot1.Plot.Axes.Bottom.Min = -0.5;
                formsPlot1.Plot.Axes.Bottom.Max = positions.Length - 0.5;

            
                formsPlot1.Plot.Axes.Margins(0, 0); 

              
                var dateTicks = allDates
                    .Select((kvp, index) => new ScottPlot.Tick(index, kvp.Key.ToString("dd MMM")))
                    .ToArray();
                formsPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(dateTicks);
                formsPlot1.Plot.Axes.Bottom.MajorTickStyle.Length = 0;

       
                formsPlot1.Plot.Axes.Bottom.Min = -0.5;
                formsPlot1.Plot.Axes.Bottom.Max = positions.Length - 0.5;

                formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
                formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot.Alignment.MiddleLeft;




                formsPlot1.Plot.Axes.Bottom.Min = -0.5;
                formsPlot1.Plot.Axes.Bottom.Max = positions.Length - 0.5;

        
                formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
                formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot.Alignment.MiddleLeft;

           
                formsPlot1.Plot.Axes.Left.Min = 0;
                formsPlot1.Plot.Axes.Left.Max = 100;

       
                List<ScottPlot.Tick> yTicks = new List<ScottPlot.Tick>();
                for (double i = 0; i <= 100; i += 10)
                {
                    yTicks.Add(new ScottPlot.Tick(i, $"{i:N0}%"));
                }
                formsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(yTicks.ToArray());


                formsPlot1.Plot.FigureBackground.Color = ScottPlot.Colors.White;
                formsPlot1.Plot.DataBackground.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(50, 240, 240, 240));

   
                formsPlot1.Plot.Axes.Margins(0, 0);
            }
            else
            {
                formsPlot1.Plot.Title("No Occupancy Data for Selected Dates");
            }

            formsPlot1.Refresh();
        }
    }
}
