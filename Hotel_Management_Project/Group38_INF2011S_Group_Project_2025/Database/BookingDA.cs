using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Group38_INF2011S_Group_Project_2025.Business;
using static Group38_INF2011S_Group_Project_2025.Business.Booking;

namespace Group38_INF2011S_Group_Project_2025.Database
{
    public class BookingDA
    {
        public Booking SaveBooking(Booking booking)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Bookings (ReferenceNumber, GuestID, RoomID, CheckInDate, CheckOutDate, 
                                NumberOfGuests, TotalAmount, DepositAmount, Status, BookingDate, NumberOfNights)
                                OUTPUT INSERTED.BookingID
                                VALUES (@RefNum, @GuestID, @RoomID, @CheckIn, @CheckOut, @NumGuests, 
                                @Total, @Deposit, @Status, @BookingDate, @Nights)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    booking.GenerateReferenceNumber();

                    cmd.Parameters.AddWithValue("@RefNum", booking.ReferenceNumber);
                    cmd.Parameters.AddWithValue("@GuestID", booking.GuestID);
                    cmd.Parameters.AddWithValue("@RoomID", booking.RoomID);
                    cmd.Parameters.AddWithValue("@CheckIn", booking.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckOut", booking.CheckOutDate);
                    cmd.Parameters.AddWithValue("@NumGuests", booking.NumberOfGuests);
                    cmd.Parameters.AddWithValue("@Total", booking.TotalAmount);
                    cmd.Parameters.AddWithValue("@Deposit", booking.DepositAmount);
                    cmd.Parameters.AddWithValue("@Status", booking.Status.ToString());
                    cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    cmd.Parameters.AddWithValue("@Nights", booking.NumberOfNights);

                    booking.BookingID = (int)cmd.ExecuteScalar();
                }
            }
            return booking;
        }

        public Booking FindBooking(string referenceNumber)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Bookings WHERE ReferenceNumber = @RefNum";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RefNum", referenceNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapBookingFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Booking FindBooking(int bookingId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Bookings WHERE BookingID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", bookingId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapBookingFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public void UpdateBooking(Booking booking)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Bookings SET CheckInDate = @CheckIn, CheckOutDate = @CheckOut,
                                NumberOfGuests = @NumGuests, TotalAmount = @Total, DepositAmount = @Deposit,
                                Status = @Status, NumberOfNights = @Nights
                                WHERE BookingID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CheckIn", booking.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckOut", booking.CheckOutDate);
                    cmd.Parameters.AddWithValue("@NumGuests", booking.NumberOfGuests);
                    cmd.Parameters.AddWithValue("@Total", booking.TotalAmount);
                    cmd.Parameters.AddWithValue("@Deposit", booking.DepositAmount);
                    cmd.Parameters.AddWithValue("@Status", booking.Status.ToString());
                    cmd.Parameters.AddWithValue("@Nights", booking.NumberOfNights);
                    cmd.Parameters.AddWithValue("@ID", booking.BookingID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM Bookings
                         WHERE CheckInDate < @EndDate AND CheckOutDate > @StartDate
                         AND Status != 'Cancelled'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(MapBookingFromReader(reader));
                        }
                    }
                }
            }
            return bookings;
        }



        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Bookings";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(MapBookingFromReader(reader));
                        }
                    }
                }
            }
            return bookings;
        }

        private Booking MapBookingFromReader(SqlDataReader reader)
        {
            return new Booking
            {
                BookingID = (int)reader["BookingID"],
                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                GuestID = (int)reader["GuestID"],
                RoomID = (int)reader["RoomID"],
                CheckInDate = (DateTime)reader["CheckInDate"],
                CheckOutDate = (DateTime)reader["CheckOutDate"],
                NumberOfGuests = (int)reader["NumberOfGuests"],
                TotalAmount = (decimal)reader["TotalAmount"],
                DepositAmount = (decimal)reader["DepositAmount"],
                Status = (BookingStatus)Enum.Parse(typeof(BookingStatus), reader["Status"].ToString()),
                BookingDate = (DateTime)reader["BookingDate"],
                NumberOfNights = (int)reader["NumberOfNights"]
            };
        }
    }
}
