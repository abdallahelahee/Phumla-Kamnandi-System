using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Group38_INF2011S_Group_Project_2025.Business;

namespace Group38_INF2011S_Group_Project_2025.Database
{

    public class RoomDA{
        public List<Room> CheckAvailability(DateTime checkIn, DateTime checkOut)
        {
            var bookingDA = new BookingDA();
            var conflictingBookings = bookingDA.GetBookingsByDateRange(checkIn, checkOut);

            List<int> bookedRoomIds = new List<int>();
            foreach (var booking in conflictingBookings)
            {
                if (!bookedRoomIds.Contains(booking.RoomID))
                {
                    bookedRoomIds.Add(booking.RoomID);
                }
            }

            List<Room> availableRooms = new List<Room>();
            List<Room> allRooms = GetAllRooms();

            foreach (var room in allRooms)
            {
                bool isBooked = false;
                foreach (var bookedId in bookedRoomIds)
                {
                    if (room.RoomID == bookedId)
                    {
                        isBooked = true;
                        break;
                    }
                }
                if (!isBooked)
                {
                    availableRooms.Add(room);
                }
            }

            return availableRooms;
        }

        public List<Room> CheckAvailability(DateTime checkIn, DateTime checkOut, RoomType roomType)
        {
            return CheckAvailability(checkIn, checkOut);
        }

        public Room GetRoom(int roomId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Rooms WHERE RoomID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", roomId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapRoomFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Rooms";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(MapRoomFromReader(reader));
                        }
                    }
                }
            }
            return rooms;
        }

        public void AdjustRoomOccupancy(int roomId, bool makeAvailable)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Rooms SET IsAvailable = @Available WHERE RoomID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Available", makeAvailable);
                    cmd.Parameters.AddWithValue("@ID", roomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Room MapRoomFromReader(SqlDataReader reader)
        {
            return new Room(
                (int)reader["RoomID"],
                reader["RoomNumber"].ToString(),
                (RoomType)Enum.Parse(typeof(RoomType), reader["RoomType"].ToString()),
                (decimal)reader["PricePerNight"],
                (int)reader["MaxOccupancy"]
            );
        }
    }
}