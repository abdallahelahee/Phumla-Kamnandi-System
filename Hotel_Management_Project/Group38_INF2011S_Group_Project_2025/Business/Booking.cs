using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group38_INF2011S_Group_Project_2025.Business
{
    public class Booking{

        #region Enumerators
        public enum BookingStatus { Pending, Confirmed, Cancelled, CheckedIn, CheckedOut}
        public enum Season { Low, Mid , High}
        #endregion

        #region Properties
        public int BookingID { get; set; }
            public string ReferenceNumber { get; set; }
            public int GuestID { get; set; }
            public int RoomID { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int NumberOfGuests { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal DepositAmount { get; set; }
            public BookingStatus Status { get; set; }
            public DateTime BookingDate { get; set; }

            public int NumberOfNights { get; set; }
        #endregion

        #region Constructors
        public Booking() 

            {
                BookingDate = DateTime.Now;
                Status = BookingStatus.Pending;
               // NumberOfNights = (CheckOutDate - CheckInDate).Days;
            }
        #endregion

        #region Methods
      public void CalculateNumberOfNights()
        {
            NumberOfNights = (CheckOutDate - CheckInDate).Days;
        }
     
        public void GenerateReferenceNumber()
            {
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            ReferenceNumber = $"HTL{DateTime.Now:yyyyMMdd}_{uniquePart}";
        }

        public void CalculateDeposit()
            {
                DepositAmount = TotalAmount * 0.10m;    //10% as specified in the test spec
            }

        public static decimal GetSeasonalRate(DateTime checkInDate)
        {
            int day = checkInDate.Day;
            int month = checkInDate.Month;

            if (month == 12)
            {
                // Low Season
                if (day >= 1 && day <= 7)
                {
                    return 550m; 
                }
                // Mid Season
                if (day >= 8 && day <= 15)
                {
                    return 750m; 
                }
                // High Season
                if (day >= 16 && day <= 31)
                {
                    return 995m; 
                }
            }
            return 550m; // Low season as default
        }
        #endregion
    }
}
