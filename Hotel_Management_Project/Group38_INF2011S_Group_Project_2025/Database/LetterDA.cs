using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Group38_INF2011S_Group_Project_2025.Business;

namespace Group38_INF2011S_Group_Project_2025.Database
{
    public class LetterDA { 
    
        public Letter CreateLetter(Letter letter)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Letters (BookingID, LetterType, Content, GeneratedDate)
                                OUTPUT INSERTED.LetterID
                                VALUES (@BookingID, @LetterType, @Content, @GeneratedDate)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", letter.BookingID);
                    cmd.Parameters.AddWithValue("@LetterType", letter.Type.ToString());
                    cmd.Parameters.AddWithValue("@Content", letter.Content ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GeneratedDate", letter.GeneratedDate);

                    letter.LetterID = (int)cmd.ExecuteScalar();
                }
            }
            return letter;
        }

        public List<Letter> GetLettersByBooking(int bookingId)
        {
            List<Letter> letters = new List<Letter>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Letters WHERE BookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            letters.Add(MapLetterFromReader(reader));
                        }
                    }
                }
            }
            return letters;
        }

        private Letter MapLetterFromReader(SqlDataReader reader)
        {
            return new Letter
            {
                LetterID = (int)reader["LetterID"],
                BookingID = (int)reader["BookingID"],
                Type = (LetterType)Enum.Parse(typeof(LetterType), reader["LetterType"].ToString()),
                Content = reader["Content"] != DBNull.Value ? reader["Content"].ToString() : null,
                GeneratedDate = (DateTime)reader["GeneratedDate"]
            };
        }
    }
}

